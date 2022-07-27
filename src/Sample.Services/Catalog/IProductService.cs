namespace Sample.Services.Catalog;

public interface IProductService
{
    Task<GetProductResult> GetProduct(string productId);
    Task<GetProductResult> GetProduct(IEnumerable<string> expands, string productId);
    Task<CatalogPage> GetCatalogPage(string path);
    Task<GetProductCollectionResult> GetProductCrossSells(string productId);
    Task<GetProductCollectionResult> GetProducts(
        string categoryId,
        List<string> expands,
        List<string> priceFilters,
        List<string> queries,
        string sortBy,
        int? pageIndex,
        int? pageSize,
        List<Guid?> attributeFilters,
        List<Guid?> brandIds,
        List<Guid?> productLineIds,
        string searchWithinQuery = null
    );
    Task<AutocompleteResult> GetAutoCompleteProducts(string query);
    Task<IEnumerable<string>> GetAllProductIds();
    Task<ProductPrice> GetProductPrice(string productId, string uom, decimal qty, bool realtime);
    Task<Product> GetProductByName(
        string productName,
        IEnumerable<string> expands
    );
    Task<GetProductCollectionResult> GetCompareProducts(List<string> expands);
    Task<GetProductCollectionResult> GetRecentlyViewedProducts();
    Task<ProductInventory> GetProductRealTimeInventory(string productId);
}
