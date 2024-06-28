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

    public async Task<PagedList<Order>> GetAllForCustomer(int customerId, OrderParameters parameters, bool trackChanges)
    {
        var items = await FindByCondintion(o => o.CustomerId.Equals(customerId), trackChanges).ToListAsync();

        return PagedList<Order>.ToPagedList(items, pageNumber: parameters.PageNumber, pageSize: parameters.PageSize);
    }

    public async Task<Order> GetForCustomerById(int customerId, int id, bool trackChanges)
        => await FindByCondintion(o => o.CustomerId == customerId, trackChanges).SingleOrDefaultAsync();

    public new void Delete(Order order) => base.Delete(order);
}