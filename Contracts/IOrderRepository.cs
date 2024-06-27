using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts;

public interface IOrderRepository
{
    void Create(Order order);

    Task<PagedList<Order>> GetAllForCustomer(string customer, OrderParameters parameters, bool trackChanges);

    Task<Order> GetForCustomerById(string customer, int id, bool trackChanges);

    void Delete(Order order);
}