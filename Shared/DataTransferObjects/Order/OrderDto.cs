﻿using Shared.DataTransferObjects.OrderDetails;

namespace Shared.DataTransferObjects.Order;

public record OrderDto(int Id, string Customer, IEnumerable<OrderDetailsDto> OrderDetailsDtos);