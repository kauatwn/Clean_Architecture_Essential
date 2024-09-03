namespace Application.DTOs.Responses.Product
{
    public sealed record CreateProductResponse
    {
        public int Id { get; }
        public string Name { get; }
        public string Description { get; }
        public int CategoryId { get; }

        public CreateProductResponse(int id, string name, string description, int categoryId)
        {
            Id = id;
            Name = name;
            Description = description;
            CategoryId = categoryId;
        }
    }
}
