using Sample.Services.Orders;

namespace Sample.Web.Features.Blocks;

public class RecentOrderBlockComponent : BlockControllerBase<RecentOrdersBlock>
{
    private readonly IOrderService _orderService;

    public RecentOrderBlockComponent(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public override async Task<IViewComponentResult> Index(RecentOrdersBlock currentBlock)
    {
        var model = new RecentOrderBlockViewModel
        {
            OrderHistoryViewModel = new OrderHistoryViewModel(),
            RecentOrdersBlock = currentBlock
        };
        model.ViewAllLink = Url.ContentUrl(model.RecentOrdersBlock.ViewAllLink);
        var searchParameters = new OrdersQueryParameters
        {
            CustomerSequence = "-1",
            PageSize = model.RecentOrdersBlock.PageSize,
            Sort = "OrderDate DESC"
        };
        var status = string.Empty;
        model.OrderHistoryViewModel.OrderCollection = await GetRecentOrder(searchParameters);
        ViewData.Model = model;
        return View(model);
    }

    public async Task<CommerceApiSDK.Models.Results.GetOrderCollectionResult> GetRecentOrder(
        OrdersQueryParameters searchParameters
    )
    {
        return await _orderService.GetOrderHistory(searchParameters);
    }
}
