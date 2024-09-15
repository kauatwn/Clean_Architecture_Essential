using Application.Abstractions.Mappings;
using Application.Abstractions.UseCases.Category;
using Application.DTOs.Requests.Category;
using Application.DTOs.Responses.Category;
using Application.Shared.Resources;
using Domain.Exceptions.Validation;
using Domain.Interfaces;
using Domain.Interfaces.Repositories.Category;
using FluentValidation;
using FluentValidation.Results;

namespace Application.UseCases.Category.Create;

public class CreateCategoryUseCase(
    IValidator<CreateCategoryRequest> validator,
    ICategoryMapper mapper,
    ICategoryReadOnlyRepository readOnlyRepository,
    ICategoryWriteOnlyRepository writeOnlyRepository,
    IUnitOfWork unitOfWork)
    : ICreateCategoryUseCase
{
    private IValidator<CreateCategoryRequest> Validator { get; } = validator;
    private ICategoryMapper Mapper { get; } = mapper;
    private ICategoryReadOnlyRepository ReadOnlyRepository { get; } = readOnlyRepository;
    private ICategoryWriteOnlyRepository WriteOnlyRepository { get; } = writeOnlyRepository;
    private IUnitOfWork UnitOfWork { get; } = unitOfWork;

    public async Task<CreateCategoryResponse> ExecuteAsync(CreateCategoryRequest request)
    {
        await ValidateAsync(request);

        var category = Mapper.RequestToDomain(request);

        await WriteOnlyRepository.AddAsync(category);
        await UnitOfWork.CommitAsync();

        var response = Mapper.DomainToResponse(category);

        return response;
    }

    private async Task ValidateAsync(CreateCategoryRequest request)
    {
        var result = await Validator.ValidateAsync(request);

        var categoryNameExists = await ReadOnlyRepository.ExistsByNameAsync(request.Name);

        if (categoryNameExists)
            result.Errors.Add(new ValidationFailure(string.Empty,
                ResourceExceptionMessages.NameAlreadyExistsMessage));

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}