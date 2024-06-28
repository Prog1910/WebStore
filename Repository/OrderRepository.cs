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

    public async Task<PagedList<Order>> GetAll(OrderParameters parameters, bool trackChanges)
    {
        var items = await FindAll(trackChanges).ToListAsync();

        return PagedList<Order>.ToPagedList(items, pageNumber: parameters.PageNumber, pageSize: parameters.PageSize);
    }

    public async Task<Order> GetById(int id, bool trackChanges)
        => await FindByCondintion(o => o.Id == id, trackChanges).SingleOrDefaultAsync();

    public new void Delete(Order order) => base.Delete(order);
}