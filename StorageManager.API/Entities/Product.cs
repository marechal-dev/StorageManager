namespace StorageManager.API.Entities;

public class Product
{
    public Guid Id { get; private init; }
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public string SKU { get; private set; } = string.Empty;
    public DateTime CreatedOnUtc { get; private init; }

    private Product() {}

    public Product(
        string title, 
        string description, 
        decimal price, 
        string sku)
    {
        Id = new Guid();
        Title = title;
        Description = description;
        Price = price;
        SKU = sku;
        CreatedOnUtc = DateTime.UtcNow;
    }

    public void Update(string? title, 
        string? description, 
        decimal? price, 
        string? sku)
    {
        Title = title ?? Title; 
        Description = description ?? Description;
        Price = price ?? Price;
        SKU = sku ?? SKU;
    }
}
