using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.Order;
using Shared.RequestFeatures;
using WebStore.Presentation.ActionFilters;

namespace WebStore.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IServiceManager _services;

    public OrdersController(IServiceManager services) => _services = services;

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> Create([FromBody] OrderForCreationDto order)
    {
        var createdOrder = await _services.OrderService.CreateAsync(order);

        return CreatedAtRoute("GetOrderById", new { createdOrder.Id }, createdOrder);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] OrderParameters parameters)
    {
        var orders = await _services.OrderService.GetAllAsync(parameters, trackChanges: false);

        return Ok(orders);
    }

    [HttpGet("{id:int}", Name = "GetOrderById")]
    public async Task<IActionResult> GetById(int id)
    {
        var order = await _services.OrderService.GetByIdAsync(id, trackChanges: false);

        return Ok(order);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _services.OrderService.DeleteAsync(id, trackChanges: false);

        return NoContent();
    }
}