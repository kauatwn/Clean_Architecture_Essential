namespace Application.Dtos.Responses.Category
{
    public sealed record CreateCategoryResponse
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string? ImageUrl { get; init; }

        public CreateCategoryResponse(int id, string name, string? imageUrl = null)
        {
            Id = id;
            Name = name;
            ImageUrl = imageUrl;
        }
    }
}
