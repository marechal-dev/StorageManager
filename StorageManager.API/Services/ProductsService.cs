using StorageManager.API.Controllers.DTOs;
using StorageManager.API.Database;
using StorageManager.API.Entities;

namespace StorageManager.API.Services;

public sealed class ProductsService
{
    private readonly ApplicationDbContext _context;
    
    private readonly int DefaultInitialPage = 1;
    private readonly int DefaultInitialPageSize = 10;

    public ProductsService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Product> FetchManyPaginated(int? page, int? pageSize)
    {
        var pageValue = page ?? DefaultInitialPage;
        var pageSizeValue = pageSize ?? DefaultInitialPageSize;
        var skipValue = (pageValue - 1) * pageSizeValue;

        List<Product> products = _context.Products
            .Skip(skipValue)
            .Take(pageSizeValue)
            .OrderBy(p => p.Title)
            .ToList();


        return products;
    }

    public Product? FetchOneById(string id)
    {
        var product = _context.Products
            .Where(p => p.Id.ToString() == id)
            .Single();

        return product;
    }

    public Product CreateNewProduct(CreateProductDto dto)
    {
        var product = new Product(
            dto.Title,
            dto.Description,
            dto.Price,
            dto.SKU);

        _context.Products.Add(product);
        _context.SaveChanges();

        return product;
    }
}
