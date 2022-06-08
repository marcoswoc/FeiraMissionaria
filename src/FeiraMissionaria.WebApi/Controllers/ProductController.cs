using FeiraMissionaria.Application.Interfaces;
using FeiraMissionaria.Application.Models.Product;
using Microsoft.AspNetCore.Mvc;

namespace FeiraMissionaria.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductApplication _application;

    public ProductController(IProductApplication application)
    {
        _application = application;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] PostProductModel model)
    {
        return Ok(await _application.CreateAsync(model));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _application.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute]Guid id)
    {
        return Ok(await _application.GetByIdAsync(id));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromBody]PostProductModel model, [FromRoute] Guid id)
    {
        await _application.UpdateAsync(model, id);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        await _application.DeleteAsync(id);
        return NoContent();
    }

}
