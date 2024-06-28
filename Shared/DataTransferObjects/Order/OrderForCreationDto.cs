using Shared.DataTransferObjects.OrderDetails;

namespace Shared.DataTransferObjects.Order;

public record OrderForCreationDto(IEnumerable<OrderDetailsForCreationDto> OrderDetails);