using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts;

public interface IOrderRepository
{
    void Create(Order order);

    Task<PagedList<Order>> GetAllForCustomer(int customerId, OrderParameters parameters, bool trackChanges);

    Task<Order> GetForCustomerById(int customerId, int id, bool trackChanges);

    void Delete(Order order);
}