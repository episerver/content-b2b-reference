namespace Sample.Services.Orders;

public interface IOrderService
{
    Task<GetOrderCollectionResult> GetOrderHistory(
        CommerceApiSDK.Models.Parameters.OrdersQueryParameters searchParameters
    );
    Task<Order> GetOrderLine(string orderNumber);
    Task<List<OrderStatusMapping>> GetOrderStatus();
}
