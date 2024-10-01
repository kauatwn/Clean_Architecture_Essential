using Domain.Common;

namespace Domain.Entities;

public sealed class Product : BaseEntity
{
    public double Price { get; private set; }
    public int Stock { get; private set; }
    public int CategoryId { get; private set; }

    public Category Category { get; private set; } = default!;

    public Product(int id, string name, string description, double price, int stock, int categoryId) : base(id, name,
        description)
    {
        Price = price;
        Stock = stock;
        CategoryId = categoryId;
    }

    public Product(string name, string description, double price, int stock, int categoryId)
        : base(name, description)
    {
        Price = price;
        Stock = stock;
        CategoryId = categoryId;
    }
}