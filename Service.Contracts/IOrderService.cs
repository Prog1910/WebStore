using Shared.DataTransferObjects.Order;
using Shared.RequestFeatures;

namespace Service.Contracts;

public interface IOrderService
{
    Task<OrderDto> CreateAsync(OrderForCreationDto order);

    Task<IEnumerable<OrderDto>> GetAllForCustomerAsync(string customer, OrderParameters parameters, bool trackChanges);

    Task<OrderDto> GetForCustomerByIdAsync(string customer, int id, bool trackChanges);

    Task DeleteForCustomerAsync(string customer, int id, bool trackChanges);
}