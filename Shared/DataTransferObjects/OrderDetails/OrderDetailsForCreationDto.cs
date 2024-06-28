namespace Shared.DataTransferObjects.OrderDetails;

public record OrderDetailsForCreationDto(int OrderId, int ProductId, int Quantity);