using AutoMapper;
using Contracts;
using Entities.Exceptions.NotFound;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects.Order;
using Shared.RequestFeatures;

namespace Service;

public class OrderService : IOrderService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public OrderService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<OrderDto> CreateAsync(OrderForCreationDto order)
    {
        var orderForDb = _mapper.Map<Order>(order);

        foreach (var orderDetails in orderForDb.OrderDetails)
        {
            orderDetails.OrderId = orderForDb.Id;
        }

        _repository.Order.Create(orderForDb);
        await _repository.SaveAsync();

        return _mapper.Map<OrderDto>(orderForDb);
    }

    public async Task<IEnumerable<OrderDto>> GetAllAsync(OrderParameters parameters, bool trackChanges)
    {
        var ordersFromDb = await _repository.Order.GetAll(parameters, trackChanges);

        return _mapper.Map<IEnumerable<OrderDto>>(ordersFromDb);
    }

    public async Task<OrderDto> GetByIdAsync(int id, bool trackChanges)
    {
        var orderFromDb = await TryGetOrderByIdAsync(id, trackChanges);

        return _mapper.Map<OrderDto>(orderFromDb);
    }

    public async Task DeleteAsync(int id, bool trackChanges)
    {
        var orderFromDb = await TryGetOrderByIdAsync(id, trackChanges);

        _repository.Order.Delete(orderFromDb);
        await _repository.SaveAsync();
    }

    private async Task<Order> TryGetOrderByIdAsync(int id, bool trackChanges)
        => await _repository.Order.GetById(id, trackChanges)
            ?? throw new OrderNotFoundException(id);
}