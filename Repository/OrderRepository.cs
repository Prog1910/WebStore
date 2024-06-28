using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;

namespace Repository;

internal sealed class OrderRepository : RepositoryBase<Order>, IOrderRepository
{
    public OrderRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    { }

    public new void Create(Order order) => base.Create(order);

    public async Task<PagedList<Order>> GetAllForCustomer(string customer, OrderParameters parameters, bool trackChanges)
    {
        var items = await FindByCondintion(o => o.Customer.Equals(customer, StringComparison.OrdinalIgnoreCase), trackChanges).ToListAsync();

        return PagedList<Order>.ToPagedList(items, pageNumber: parameters.PageNumber, pageSize: parameters.PageSize);
    }

    public async Task<Order> GetForCustomerById(string customer, int id, bool trackChanges)
        => await FindByCondintion(o => o.Customer.Equals(customer, StringComparison.OrdinalIgnoreCase), trackChanges).SingleOrDefaultAsync();

    public new void Delete(Order order) => base.Delete(order);
}