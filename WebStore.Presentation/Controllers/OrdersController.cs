using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.Order;
using Shared.RequestFeatures;
using WebStore.Presentation.ActionFilters;

namespace WebStore.Presentation.Controllers;

[Route("api/customers/{customerId:int}/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IServiceManager _services;

    public OrdersController(IServiceManager services) => _services = services;

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> Create(int customerId, [FromBody] OrderForCreationDto order)
    {
        var createdOrder = await _services.OrderService.CreateAsync(order);

        return CreatedAtRoute("GetOrderForCustomerById", new { customerId, createdOrder.Id }, createdOrder);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(int customerId, [FromQuery] OrderParameters parameters)
    {
        var orders = await _services.OrderService.GetAllForCustomerAsync(customerId, parameters, trackChanges: false);

        return Ok(orders);
    }

    [HttpGet("{id:int}", Name = "GetOrderForCustomerById")]
    public async Task<IActionResult> GetById(int customerId, int id)
    {
        var order = await _services.OrderService.GetForCustomerByIdAsync(customerId, id, trackChanges: false);

        return Ok(order);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int customerId, int id)
    {
        await _services.OrderService.DeleteForCustomerAsync(customerId, id, trackChanges: false);

        return NoContent();
    }
}