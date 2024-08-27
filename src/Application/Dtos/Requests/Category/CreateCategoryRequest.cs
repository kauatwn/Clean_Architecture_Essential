namespace Application.Dtos.Requests.Category
{
    public sealed record CreateCategoryRequest
    {
        public string Name { get; init; }

        public CreateCategoryRequest(string name)
        {
            Name = name;
        }
    }
}
