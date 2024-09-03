using Application.Abstractions.Mappings;
using Application.DTOs.Requests.Category;
using Application.DTOs.Responses.Category;

namespace Application.Mappings.Category
{
    public class CategoryMapper : ICategoryMapper
    {
        public Domain.Entities.Category RequestToDomain(CreateCategoryRequest request)
        {
            return new Domain.Entities.Category(request.Name);
        }

        public CreateCategoryResponse DomainToResponse(Domain.Entities.Category category)
        {
            return new CreateCategoryResponse(category.Id, category.Name);
        }
    }
}
