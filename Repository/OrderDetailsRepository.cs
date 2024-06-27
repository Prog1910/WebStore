using Contracts;
using Entities.Models;

namespace Repository;

internal sealed class OrderDetailsRepository : RepositoryBase<OrderDetails>, IOrderDetailsRepository
{
    public OrderDetailsRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    { }
}