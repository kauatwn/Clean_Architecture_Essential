using Application.Dtos.Requests.Category;
using Application.Dtos.Responses.Category;

namespace Application.Abstractions.UseCases.Category
{
    public interface ICreateCategoryUseCase
    {
        Task<CreateCategoryResponse> ExecuteAsync(CreateCategoryRequest request);
    }
}
