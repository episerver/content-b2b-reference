namespace Sample.Services.Orders;

public class OrderService : BaseService, IOrderService
{
    private readonly CommerceApiSDK.Services.Interfaces.IOrderService _orderClient;

    public OrderService(CommerceApiSDK.Services.Interfaces.IOrderService orderClient)
    {
        _orderClient = orderClient;
    }

    public async Task<GetOrderCollectionResult> GetOrderHistory(
        OrdersQueryParameters ordersQueryParameters
    )
    {
        return await _orderClient.GetOrders(ordersQueryParameters);
    }

    public async Task<Order> GetOrderLine(string orderNumber)
    {
        return await _orderClient.GetOrder(orderNumber);
    }

    public async Task<List<OrderStatusMapping>> GetOrderStatus()
    {
        return await _orderClient.GetOrderStatusMappings();
    }
}
