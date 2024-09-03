namespace Application.DTOs.Responses.Category
{
    public sealed record CreateCategoryResponse
    {
        public int Id { get; }
        public string Name { get; }

        public CreateCategoryResponse(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
