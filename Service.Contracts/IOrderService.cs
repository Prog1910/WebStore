using Shared.DataTransferObjects.Order;
using Shared.RequestFeatures;

namespace Service.Contracts;

public interface IOrderService
{
    Task<OrderDto> CreateAsync(OrderForCreationDto order);

    Task<IEnumerable<OrderDto>> GetAllForCustomerAsync(int customerId, OrderParameters parameters, bool trackChanges);

    Task<OrderDto> GetForCustomerByIdAsync(int customerId, int id, bool trackChanges);

    Task DeleteForCustomerAsync(int customerId, int id, bool trackChanges);
}