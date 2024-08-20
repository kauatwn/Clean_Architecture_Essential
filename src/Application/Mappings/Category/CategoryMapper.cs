using Application.Abstractions.Mappings;
using Application.Dtos.Requests.Category;
using Application.Dtos.Responses.Category;

namespace Application.Mappings.Category
{
    public class CategoryMapper : ICategoryMapper
    {
        public Domain.Entities.Category RequestToDomain(CreateCategoryRequest request)
        {
            return new Domain.Entities.Category(request.Name, request.ImageUrl);
        }

        public CreateCategoryResponse DomainToResponse(Domain.Entities.Category category)
        {
            return new CreateCategoryResponse(category.Id, category.Name, category.ImageUrl);
        }
    }
}
