using Contracts;
using Service.Contracts;

namespace Service;

public class OrderService : IOrderService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public OrderService(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }
}