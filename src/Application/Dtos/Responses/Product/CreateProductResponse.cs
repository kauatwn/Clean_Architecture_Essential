namespace Application.Dtos.Responses.Product
{
    public sealed record CreateProductResponse
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public int CategoryId { get; init; }

        public CreateProductResponse(int id, string name, string description, int categoryId)
        {
            Id = id;
            Name = name;
            Description = description;
            CategoryId = categoryId;
        }
    }
}
