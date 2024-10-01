using Application.Abstractions.Mappings;
using Application.DTOs.Requests.Category;
using Application.DTOs.Responses.Category;

namespace Application.Mappings.Category;

public class CategoryMapper : ICategoryMapper
{
    public Domain.Entities.Category RequestToDomain(CreateCategoryRequest request)
    {
        return new Domain.Entities.Category(request.Name, request.Description);
    }

    public CategoryResponse DomainToResponse(Domain.Entities.Category category)
    {
        return new CategoryResponse(category.Id, category.Name);
    }
}