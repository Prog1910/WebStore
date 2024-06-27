using Contracts;

namespace Repository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IOrderRepository> _orderRepository;
    private readonly Lazy<IProductRepository> _productRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _orderRepository = new Lazy<IOrderRepository>(() => new OrderRepository(repositoryContext));
        _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(repositoryContext));
    }

    public IOrderRepository Order => _orderRepository.Value;

    public IProductRepository Product => _productRepository.Value;

    public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
}