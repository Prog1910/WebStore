using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts;

public interface IOrderRepository
{
    void Create(Order order);

    Task<PagedList<Order>> GetAll(OrderParameters parameters, bool trackChanges);

    Task<Order> GetById(int id, bool trackChanges);

    void Delete(Order order);
}