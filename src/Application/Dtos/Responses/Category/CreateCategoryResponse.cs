namespace Application.Dtos.Responses.Category
{
    public sealed record CreateCategoryResponse
    {
        public int Id { get; init; }
        public string Name { get; init; }

        public CreateCategoryResponse(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
