using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts;

public interface IOrderRepository
{
    void CreateForCustomer(string customer, Order order);

    Task<PagedList<Order>> GetAllForCustomer(string customer, OrderParameters parameters, bool trackChanges);

    void Delete(Order order);
}