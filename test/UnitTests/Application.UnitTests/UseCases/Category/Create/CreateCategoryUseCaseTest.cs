using Application.Abstractions.Mappings;
using Application.DTOs.Requests.Category;
using Application.DTOs.Responses.Category;
using Application.Shared.Constants;
using Application.Shared.Resources;
using Application.UseCases.Category.Create;
using Bogus;
using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Interfaces.Repositories.Category;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Application.UnitTests.UseCases.Category.Create;

public class CreateCategoryUseCaseTest
{
    private Mock<IValidator<CreateCategoryRequest>> ValidatorMock { get; } = new();
    private Mock<ICategoryMapper> MapperMock { get; } = new();
    private Mock<ICategoryReadOnlyRepository> ReadOnlyRepositoryMock { get; } = new();
    private Mock<ICategoryWriteOnlyRepository> WriteOnlyRepositoryMock { get; } = new();
    private Mock<IUnitOfWork> UnitOfWorkMock { get; } = new();
    private CreateCategoryUseCase UseCase { get; }

    private Faker<CreateCategoryRequest> RequestFaker { get; } = new Faker<CreateCategoryRequest>()
        .CustomInstantiator(f => new CreateCategoryRequest(f.Commerce.Department(), f.Commerce.ProductDescription()));

    public CreateCategoryUseCaseTest()
    {
        UseCase = new CreateCategoryUseCase(
            ValidatorMock.Object,
            MapperMock.Object,
            ReadOnlyRepositoryMock.Object,
            WriteOnlyRepositoryMock.Object,
            UnitOfWorkMock.Object);
    }

    [Fact]
    public async Task ShouldReturnCreateCategoryResponseWhenRequestIsValid()
    {
        // Arrange
        var request = RequestFaker.Generate();
        
        var category = new Domain.Entities.Category(request.Name, request.Description);
        var expectedResponse = new CategoryResponse(category.Id, category.Name);

        ValidatorMock.Setup(v => v.ValidateAsync(It.IsAny<CreateCategoryRequest>(), default))
            .ReturnsAsync(new ValidationResult());

        ReadOnlyRepositoryMock.Setup(r => r.ExistsByNameAsync(It.IsAny<string>()))
            .ReturnsAsync(false);

        MapperMock.Setup(m => m.RequestToDomain(It.IsAny<CreateCategoryRequest>()))
            .Returns(category);

        MapperMock.Setup(m => m.DomainToResponse(It.IsAny<Domain.Entities.Category>()))
            .Returns(expectedResponse);

        WriteOnlyRepositoryMock.Setup(r => r.AddAsync(It.IsAny<Domain.Entities.Category>()))
            .Returns(Task.CompletedTask);

        UnitOfWorkMock.Setup(u => u.CommitAsync())
            .Returns(Task.CompletedTask);

        // Act
        var response = await UseCase.ExecuteAsync(request);

        // Assert
        response.Id.Should().Be(expectedResponse.Id);
        response.Name.Should().Be(expectedResponse.Name);
    }

    [Fact]
    public async Task ShouldThrowErrorOnValidationExceptionWhenRequestIsInvalid()
    {
        // Arrange
        var request = RequestFaker.Generate();

        var emptyNameErrorMessage = ResourceExceptionMessages.NullOrEmptyNameMessage;
        var nameLengthErrorMessage = string.Format(
            ResourceExceptionMessages.NameLengthMessage,
            FieldValidation.NameMinLength,
            FieldValidation.NameMaxLength);

        var validationFailures = new List<ValidationFailure>
        {
            new(string.Empty, emptyNameErrorMessage),
            new(string.Empty, nameLengthErrorMessage)
        };

        ValidatorMock.Setup(v => v.ValidateAsync(It.IsAny<CreateCategoryRequest>(), default))
            .ReturnsAsync(new ValidationResult(validationFailures));

        ReadOnlyRepositoryMock.Setup(r => r.ExistsByNameAsync(It.IsAny<string>()))
            .ReturnsAsync(false);

        // Act
        var act = async () => await UseCase.ExecuteAsync(request);

        // Assert
        await act.Should().ThrowAsync<ErrorOnValidationException>();
    }

    [Fact]
    public async Task ShouldThrowErrorOnValidationExceptionWhenCategoryNameExists()
    {
        // Arrange
        var request = RequestFaker.Generate();

        var nameAlreadyExistsErrorMessage = ResourceExceptionMessages.NameAlreadyExistsMessage;

        var validationFailures = new List<ValidationFailure>
        {
            new(string.Empty, nameAlreadyExistsErrorMessage)
        };

        ValidatorMock.Setup(v => v.ValidateAsync(It.IsAny<CreateCategoryRequest>(), default))
            .ReturnsAsync(new ValidationResult(validationFailures));

        ReadOnlyRepositoryMock.Setup(r => r.ExistsByNameAsync(It.IsAny<string>()))
            .ReturnsAsync(true);

        // Act
        var act = async () => await UseCase.ExecuteAsync(request);

        // Assert
        await act.Should().ThrowAsync<ErrorOnValidationException>();
    }
}