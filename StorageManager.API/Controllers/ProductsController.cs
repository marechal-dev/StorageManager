using Microsoft.AspNetCore.Mvc;
using StorageManager.API.Controllers.DTOs;
using StorageManager.API.Services;

namespace StorageManager.API.Controllers;

[ApiController]
[Route("products")]
public class ProductsController : ControllerBase
{
    private readonly ProductsService _productsService;

    public ProductsController(ProductsService productsService)
    {
        _productsService = productsService;
    }

    [HttpGet("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IResult FetchMany([FromQuery(Name = "page")] int? page, 
        [FromQuery(Name = "pageSize")] int? pageSize) 
    {
        var products = _productsService.FetchManyPaginated(page, pageSize);
        
        return Results.Ok(products);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IResult FetchOneById([FromRoute] string id)
    {
        var product = _productsService.FetchOneById(id);

        if (product is null)
        {
            return Results.NotFound();
        }

        return Results.Ok(product);
    }

    [HttpPost("")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IResult Create([FromBody] CreateProductDto dto) 
    {
        var createdProduct = _productsService.CreateNewProduct(dto);

        return Results.Created("/products", createdProduct);
    }
}
