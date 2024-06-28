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
        var ordersWithoutDetails = FindAll(trackChanges);
        var orders = IncludeOrderDetails(ordersWithoutDetails, trackChanges);

        var items = await orders.ToListAsync();

        return PagedList<Order>.ToPagedList(items, pageNumber: parameters.PageNumber, pageSize: parameters.PageSize);
    }

    public async Task<Order> GetById(int id, bool trackChanges)
    {
        var orderWithoutDetails = FindByCondintion(o => o.Id == id, trackChanges);

        var order = IncludeOrderDetails(orderWithoutDetails, trackChanges);

        return await order.SingleOrDefaultAsync();
    }

    public new void Delete(Order order) => base.Delete(order);

    private static IQueryable<Order> IncludeOrderDetails(IQueryable<Order> ordersWithoutDetails, bool trackChanges)
        => trackChanges
            ? ordersWithoutDetails.Include(o => o.OrderDetails)
            : ordersWithoutDetails.Include(o => o.OrderDetails).AsNoTracking();
}