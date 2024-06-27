using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IOrderService> _orderService;

    private readonly Lazy<IProductService> _productService;

    public ServiceManager(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _orderService = new Lazy<IOrderService>(() => new OrderService(repository, logger, mapper));
        _productService = new Lazy<IProductService>(() => new ProductService(repository, logger, mapper));
    }

    public IOrderService OrderService => _orderService.Value;

    public IProductService ProductService => _productService.Value;
}