using Contracts;

namespace Repository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IOrderRepository> _orderRepository;
    private readonly Lazy<IProductRepository> _productRepository;
    private readonly Lazy<IOrderDetailsRepository> _orderDetailsRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _orderRepository = new Lazy<IOrderRepository>(() => new OrderRepository(repositoryContext));
        _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(repositoryContext));
        _orderDetailsRepository = new Lazy<IOrderDetailsRepository>(() => new OrderDetailsRepository(repositoryContext));
    }

    public IOrderRepository Order => _orderRepository.Value;

    public IProductRepository Product => _productRepository.Value;

    public IOrderDetailsRepository OrdersDetails => _orderDetailsRepository.Value;

    public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
}