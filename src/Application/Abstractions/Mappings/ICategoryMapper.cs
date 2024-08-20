using Application.Dtos.Requests.Category;
using Application.Dtos.Responses.Category;

namespace Application.Abstractions.Mappings
{
    public interface ICategoryMapper
    {
        Domain.Entities.Category RequestToDomain(CreateCategoryRequest request);
        CreateCategoryResponse DomainToResponse(Domain.Entities.Category category);
    }
}
