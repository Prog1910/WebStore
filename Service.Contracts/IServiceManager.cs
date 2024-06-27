namespace Service.Contracts;

public interface IServiceManager
{
    public IOrderService OrderService { get; }

    public IProductService ProductService { get; }
}