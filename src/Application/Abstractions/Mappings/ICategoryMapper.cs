using Application.DTOs.Requests.Category;
using Application.DTOs.Responses.Category;

namespace Application.Abstractions.Mappings
{
    public interface ICategoryMapper
    {
        Domain.Entities.Category RequestToDomain(CreateCategoryRequest request);
        CreateCategoryResponse DomainToResponse(Domain.Entities.Category category);
    }
}
