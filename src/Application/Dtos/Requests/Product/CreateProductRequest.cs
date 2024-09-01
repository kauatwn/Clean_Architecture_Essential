namespace Application.DTOs.Requests.Product
{
    public sealed record CreateProductRequest
    {
        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }
        public int Stock { get; }
        public int CategoryId { get; }

        public CreateProductRequest(string name, string description, decimal price, int stock, int categoryId)
        {
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            CategoryId = categoryId;
        }
    }
}
