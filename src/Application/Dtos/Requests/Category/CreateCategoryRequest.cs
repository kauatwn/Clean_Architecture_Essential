namespace Application.Dtos.Requests.Category
{
    public sealed record CreateCategoryRequest
    {
        public string Name { get; init; }
        public string? ImageUrl { get; init; }

        public CreateCategoryRequest(string name, string? imageUrl = null)
        {
            Name = name;
            ImageUrl = imageUrl;
        }
    }
}
