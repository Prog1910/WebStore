namespace Contracts;

public interface IRepositoryManager
{
    IOrderRepository Order { get; }
    IProductRepository Product { get; }

    Task SaveAsync();
}