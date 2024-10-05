using Application.Abstractions.UseCases.Category;
using Application.DTOs.Requests.Category;
using Application.DTOs.Responses.Category;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType<CategoryResponse>(StatusCodes.Status201Created)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Create(ICreateCategoryUseCase useCase, CreateCategoryRequest request)
    {
        var result = await useCase.ExecuteAsync(request);

        return Created(string.Empty, result);
    }
}