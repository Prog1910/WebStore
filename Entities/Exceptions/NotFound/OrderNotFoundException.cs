namespace Entities.Exceptions.NotFound;

public sealed class OrderNotFoundException : NotFoundException
{
    public OrderNotFoundException(int customerId, int id) : base($"Order with id: {id} for customer with Id: {customerId} not found.")
    { }
}