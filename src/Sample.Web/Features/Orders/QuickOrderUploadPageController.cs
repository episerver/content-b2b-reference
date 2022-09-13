using EPiServer.Logging;
using CommerceApiSettings = Sample.Web.Infrastructure.CommerceApiSettings;
using Sample.Services.Catalog;
using Sample.Services.Cart;

namespace Sample.Web.Features.Orders;

public class QuickOrderUploadPageController : PageControllerBase<QuickOrderUploadPage>
{
    private readonly IProductService _productService;
    private readonly ICartService _cartService;
    private readonly CommerceApiSettings _commerceApiSettings;

    public QuickOrderUploadPageController(
        IProductService productService,
        CartService cartService,
        IOptionsMonitor<CommerceApiSettings> commerceApiSettings
    )
    {
        _productService = productService;
        _cartService = cartService;
        _commerceApiSettings = commerceApiSettings.CurrentValue;
    }

    public async Task<IActionResult> Index(QuickOrderUploadPage currentPage)
    {
        var model = new QuickOrderUploadPageViewModel(currentPage);
        return await Task.FromResult(View(model));
    }

    [HttpPost]
    public async Task<IActionResult> AddToQuickOrder(string productId, string qty)
    {
        if (string.IsNullOrEmpty(qty))
        {
            qty = "1";
        }
        var product = await _productService.GetProduct(productId);
        product.Product.ProductDetailUrl = GetProductDetailsUrl(
            product.Product.ProductDetailUrl
        );
        return Json(product.Product);
    }

    [HttpPost]
    public async Task<IActionResult> CheckOutQuickOrder(
        List<ProductViewModel> productList,
        QuickOrderUploadPage currentPage
    )
    {
        try
        {
            var cartPageRedirectUrl = Url.ContentUrl(currentPage.CartPageRedirectUrl);
            if (string.IsNullOrWhiteSpace(cartPageRedirectUrl))
            {
                LogManager.GetLogger(GetType()).Error("Cart Redirect Url is empty.");
            }
            var cartLineCollection = new List<AddCartLine>();
            foreach (var product in productList)
            {
                var cartLine = new AddCartLine()
                {
                    ProductId = product.Id,
                    QtyOrdered = product.QtyOrdered,
                    UnitOfMeasure = product.UnitOfMeasure
                };
                cartLineCollection.Add(cartLine);
            }
            var result = await _cartService.AddAllToCart(cartLineCollection);
            var isSuccess = result.Any();
            return Json(new { isSuccess, cartPageRedirectUrl });
        }
        catch (Exception ex)
        {
            LogManager.GetLogger(GetType()).Error($"{ex.Message}");
            return Json(new { isSuccess = false });
        }
    }

    public async Task<Product> GetProductDetails(string productName, string uom, string qty)
    {
        var expands = new List<string>() { "pricing" };
        var result = await _productService.GetProductByName(productName, expands);
        if (result != null)
        {
            uom = !string.IsNullOrEmpty(uom) ? uom : result.UnitOfMeasureDisplay;
            if (!int.TryParse(qty, out var quantity))
                quantity = 1;
            else
                quantity = quantity > 0 ? quantity : 1;

            if (
                quantity > 1
                ||
                    !string.IsNullOrEmpty(uom)
                    && !result.UnitOfMeasureDisplay.Equals(
                        uom.Trim(),
                        StringComparison.OrdinalIgnoreCase
                    )

            )
            {
                var prices = await _productService.GetProductPrice(result.Id.ToString(), uom, decimal.Parse(qty));
                if (prices != null)
                {
                    if (
                        result.ProductUnitOfMeasures
                            .Where(
                                u =>
                                    u.UnitOfMeasure.Equals(
                                        uom,
                                        StringComparison.OrdinalIgnoreCase
                                    )
                            )
                            .FirstOrDefault() != null
                    )
                    {
                        result.UnitOfMeasureDisplay = uom;
                        result.UnitOfMeasure = uom;
                        foreach (var item in result.ProductUnitOfMeasures)
                        {
                            if (
                                item.UnitOfMeasure.Equals(
                                    uom,
                                    StringComparison.OrdinalIgnoreCase
                                )
                            )
                                item.IsDefault = true;
                            else
                                item.IsDefault = false;
                        }
                    }
                    result.QtyOrdered = quantity;
                    result.Pricing.UnitNetPrice = prices.UnitNetPrice;
                    result.Pricing.UnitNetPriceDisplay = prices.UnitNetPriceDisplay;
                    result.Pricing.ExtendedUnitNetPrice = prices.ExtendedUnitNetPrice;
                    result.Pricing.ExtendedUnitNetPriceDisplay =
                        prices.ExtendedUnitNetPriceDisplay;
                }
            }
            else
                result.QtyOrdered = Convert.ToInt32(qty);

            result.ProductDetailUrl = "";
        }
        return result;
    }

    private string GetProductDetailsUrl(string productUrlSegment)
    {
        return $"/{LanguageSelector.AutoDetect().Language.TwoLetterISOLanguageName}{productUrlSegment}";
    }

    [HttpGet]
    public async Task<IActionResult> AutoCompleteProducts(string query)
    {
        var result = await _productService.GetAutoCompleteProducts(query);
        if (result != null && result.Products != null && result.Products.Count > 0)
        {
            var lstProductJson = new List<AutocompleteProductsJsonViewModel>();
            foreach (var product in result.Products)
            {
                lstProductJson.Add(
                    new AutocompleteProductsJsonViewModel()
                    {
                        productId = product.Id.ToString(),
                        label = product.Title,
                        value = product.Name,
                        Name = product.ErpNumber,
                        Image = GetImageUrl(product.Image),
                        productUrl = GetProductDetailsUrl(product.Url),
                        type = "0"
                    }
                );
            }

            return Json(lstProductJson);
        }
        return Json(null);
    }

    private string GetImageUrl(string productImageUrlSegment)
    {
        return _commerceApiSettings.baseUrl + productImageUrlSegment;
    }

    [HttpPost]
    public async Task<IActionResult> OrderUpload(List<string> items, string goalId)
    {
        var isSuccess = false;
        var validProducts = new List<Product>();
        var invalidProducts = new List<string>();
        var canNotAddToCartProducts = new List<Product>();
        var isNotActiveProducts = new List<Product>();
        var outOfStockProducts = new List<Product>();
        var invalidQtyProducts = new List<string>();
        var invalidUomProducts = new List<string>();
        var errorMessage = string.Empty;

        if (items != null && items.Count > 0)
        {
            foreach (var item in items)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    var pDetails = item.Contains(",") ? item.Split(',') : new string[] { };
                    var productName = pDetails.Length > 0 ? pDetails[0].Trim() : item.Trim();
                    var quantity =
                        pDetails.Length > 1
                            ?
                                  !string.IsNullOrEmpty(pDetails[1].Trim())
                                      ? pDetails[1].Trim()
                                      : "1"

                            : "1";
                    int checkQty;

                    if (int.TryParse(quantity, out checkQty))
                        quantity = Convert.ToInt32(checkQty) > 0 ? quantity : "1";
                    else
                    {
                        invalidQtyProducts.Add(quantity);
                        continue;
                    }
                    var uom =
                        pDetails.Length > 2
                            ?
                                  !string.IsNullOrEmpty(pDetails[2].Trim())
                                      ? pDetails[2].Trim()
                                      : string.Empty

                            : string.Empty;

                    var product = !invalidProducts.Contains(productName)
                        ? await GetProductDetails(productName, uom, quantity)
                        : null;
                    if (product != null)
                    {
                        if (!product.IsActive)
                            isNotActiveProducts.Add(product);
                        else if (

                                !string.IsNullOrEmpty(uom)
                                && !product.UnitOfMeasureDisplay.Equals(
                                    uom.Trim(),
                                    StringComparison.OrdinalIgnoreCase
                                )

                        )
                            invalidUomProducts.Add(uom);
                        else if (!product.CanAddToCart)
                            canNotAddToCartProducts.Add(product);
                        else
                            validProducts.Add(product);
                    }
                    else
                    {
                        if (!invalidProducts.Contains(productName))
                            invalidProducts.Add(productName);
                    }
                }
            }
            if (validProducts.Count == items.Count)
            {
                isSuccess = true;
                errorMessage = string.Empty;
            }
            else
            {
                isSuccess = false;
                errorMessage = invalidProducts.Aggregate(
                    errorMessage,
                    (current, name) => current + name + " is an invalid product.<br>"
                );
                errorMessage = invalidUomProducts.Aggregate(
                    errorMessage,
                    (current, name) => current + name + " is an invalid UOM.<br>"
                );
                errorMessage = invalidQtyProducts.Aggregate(
                    errorMessage,
                    (current, name) => current + name + " is an invalid quanitity.<br>"
                );
                errorMessage = canNotAddToCartProducts.Aggregate(
                    errorMessage,
                    (current, product) =>
                        current + product.Name + " can not be added to cart.<br>"
                );
                errorMessage = isNotActiveProducts.Aggregate(
                    errorMessage,
                    (current, product) =>
                        current + product.Name + " is not an active product.<br>"
                );
                errorMessage = outOfStockProducts.Aggregate(
                    errorMessage,
                    (current, product) => current + product.Name + " is out of stock.<br>"
                );
            }
        }
        if (!string.IsNullOrEmpty(goalId))
            isSuccess = true;
        return Json(
            new
            {
                IsSuccess = isSuccess,
                ErrorMessage = errorMessage,
                ValidProducts = validProducts,
                InValidProducts = invalidProducts
            }
        );
    }
}
