namespace Entities.Exceptions.NotFound;

public sealed class OrderNotFoundException : NotFoundException
{
    public OrderNotFoundException(int id) : base($"Order with id: {id} not found.")
    { }
}