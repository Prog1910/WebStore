using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.Product;
using Shared.RequestFeatures;
using WebStore.Presentation.ActionFilters;

namespace WebStore.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IServiceManager _services;

    public ProductsController(IServiceManager services) => _services = services;

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> Add([FromBody] ProductForCreationDto product)
    {
        var addedProduct = await _services.ProductService.AddAsync(product);

        return CreatedAtRoute("GetProductById", addedProduct.Id, addedProduct);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] ProductParameters parameters)
    {
        var products = await _services.ProductService.GetAllAsync(parameters, trackChanges: false);

        return Ok(products);
    }

    [HttpGet("id:int", Name = "GetProductById")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _services.ProductService.GetByIdAsync(id, trackChanges: false);

        return Ok(product);
    }

    [HttpDelete("id:int")]
    public async Task<IActionResult> Remove(int id)
    {
        await _services.ProductService.RemoveAsync(id, trackChanges: false);

        return NoContent();
    }
}