using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;

namespace Repository;

internal sealed class OrderRepository : RepositoryBase<Order>, IOrderRepository
{
    public OrderRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    { }

    public void CreateForCustomer(string customer, Order order)
    {
        order.Customer = customer;

        Create(order);
    }

    public async Task<PagedList<Order>> GetAllForCustomer(string customer, OrderParameters parameters, bool trackChanges)
    {
        var items = await FindByCondintion(o => o.Customer.Equals(customer, StringComparison.OrdinalIgnoreCase), trackChanges).ToListAsync();

        return PagedList<Order>.ToPagedList(items, pageNumber: parameters.PageNumber, pageSize: parameters.PageSize);
    }

    private new void Delete(Order order) => Delete(order);
}