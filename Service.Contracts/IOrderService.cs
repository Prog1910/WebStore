using Shared.DataTransferObjects.Order;
using Shared.RequestFeatures;

namespace Service.Contracts;

public interface IOrderService
{
    Task<OrderDto> CreateAsync(OrderForCreationDto order);

    Task<IEnumerable<OrderDto>> GetAllAsync(OrderParameters parameters, bool trackChanges);

    Task<OrderDto> GetByIdAsync(int id, bool trackChanges);

    Task DeleteAsync(int id, bool trackChanges);
}