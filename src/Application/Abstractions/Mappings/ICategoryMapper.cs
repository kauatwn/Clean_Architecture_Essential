using Application.DTOs.Requests.Category;
using Application.DTOs.Responses.Category;
using Domain.Entities;

namespace Application.Abstractions.Mappings;

public interface ICategoryMapper
{
    Category RequestToDomain(CreateCategoryRequest request);
    CreateCategoryResponse DomainToResponse(Category category);
}