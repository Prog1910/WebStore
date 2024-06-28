namespace Entities.Exceptions.NotFound;

public sealed class OrderNotFoundException : NotFoundException
{
    public OrderNotFoundException(string customer, int id) : base($"Order with id: {id} and customer: {customer} not found.")
    { }
}