using Application.DTOs.Requests.Category;
using Application.DTOs.Responses.Category;

namespace Application.Abstractions.UseCases.Category
{
    public interface ICreateCategoryUseCase
    {
        Task<CreateCategoryResponse> ExecuteAsync(CreateCategoryRequest request);
    }
}
