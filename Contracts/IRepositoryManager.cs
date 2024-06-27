namespace Contracts;

public interface IRepositoryManager
{
    IOrderRepository Order { get; }
    IProductRepository Product { get; }
    IOrderDetailsRepository OrdersDetails { get; }

    Task SaveAsync();
}