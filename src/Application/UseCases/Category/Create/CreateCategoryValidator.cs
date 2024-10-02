using Application.DTOs.Requests.Category;
using Application.Shared.Constants;
using Application.Shared.Resources;
using FluentValidation;

namespace Application.UseCases.Category.Create;

public class CreateCategoryValidator : AbstractValidator<CreateCategoryRequest>
{
    public CreateCategoryValidator()
    {
        RuleFor(r => r.Name)
            .NotEmpty()
            .WithMessage(ResourceExceptionMessages.NullOrEmptyNameMessage)
            .Length(FieldValidation.NameMinLength, FieldValidation.NameMaxLength)
            .WithMessage(string.Format(
                ResourceExceptionMessages.NameLengthMessage,
                FieldValidation.NameMinLength,
                FieldValidation.NameMaxLength));
    }
}