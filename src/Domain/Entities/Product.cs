using Domain.Common;

namespace Domain.Entities
{
    public sealed class Product : BaseEntity
    {
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public int CategoryId { get; private set; }

        public Category? Category { get; }

        public Product(string name, string description, decimal price, int stock, int categoryId) : base(name)
        {
            Description = description;
            Price = price;
            Stock = stock;
            CategoryId = categoryId;
        }
    }
}
