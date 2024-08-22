namespace Application.Dtos.Requests.Product
{
    public sealed record CreateProductRequest
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public decimal Price { get; init; }
        public int Stock {  get; init; }
        public string? ImageUrl { get; init; }
        public int CategoryId { get; init; }

        public CreateProductRequest(string name, string description, decimal price, int stock, int categoryId, string? imageUrl = null)
        {
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            CategoryId = categoryId;
            ImageUrl = imageUrl;
        }
    }
}
