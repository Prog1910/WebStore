namespace Shared.DataTransferObjects.Order;

public record OrderForCreationDto(int Id, string Customer, IEnumerable<OrderDetailsForCreationDto> OrderDetailsDtos);