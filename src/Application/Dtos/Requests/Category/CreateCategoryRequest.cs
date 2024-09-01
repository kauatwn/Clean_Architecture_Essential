namespace Application.DTOs.Requests.Category
{
    public sealed record CreateCategoryRequest
    {
        public string Name { get; }
        
        public CreateCategoryRequest(string name)
        {
            Name = name;
        }
    }
}
