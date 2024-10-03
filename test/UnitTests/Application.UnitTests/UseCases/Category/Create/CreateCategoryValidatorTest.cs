﻿using Application.DTOs.Requests.Category;
using Application.Shared.Constants;
using Application.Shared.Resources;
using Application.UseCases.Category.Create;
using Bogus;
using FluentValidation.TestHelper;

namespace Application.UnitTests.UseCases.Category.Create;

public class CreateCategoryValidatorTest
{
    private CreateCategoryValidator Validator { get; } = new();
    private Faker Faker { get; } = new();

    [Fact]
    public void ShouldNotHaveErrorWhenNameIsValid()
    {
        // Arrange
        var validName = Faker.Commerce.Department();
        var validDescription = Faker.Commerce.ProductDescription();
        var request = new CreateCategoryRequest(validName, validDescription);

        // Act
        var result = Validator.TestValidate(request);

        // Assert
        result.ShouldNotHaveValidationErrorFor(r => r.Name);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void ShouldHaveErrorWhenNameIsNullOrEmpty(string? invalidName)
    {
        // Arrange
        var validDescription = Faker.Commerce.ProductDescription();
        var request = new CreateCategoryRequest(invalidName!, validDescription);

        // Act
        var result = Validator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(r => r.Name)
            .WithErrorMessage(ResourceExceptionMessages.NullOrEmptyNameMessage);
    }

    [Fact]
    public void ShouldHaveErrorWhenNameIsTooShort()
    {
        // Arrange
        var shortName = Faker.Lorem.Letter(FieldValidation.NameMinLength - 1);
        var validDescription = Faker.Commerce.ProductDescription();
        var request = new CreateCategoryRequest(shortName, validDescription);

        // Act
        var result = Validator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(r => r.Name)
            .WithErrorMessage(string.Format(
                ResourceExceptionMessages.NameLengthMessage,
                FieldValidation.NameMinLength,
                FieldValidation.NameMaxLength));
    }

    [Fact]
    public void ShouldHaveErrorWhenNameIsTooLong()
    {
        // Arrange
        var longName = Faker.Lorem.Letter(FieldValidation.NameMaxLength + 1);
        var validDescription = Faker.Commerce.ProductDescription();
        var request = new CreateCategoryRequest(longName, validDescription);

        // Act
        var result = Validator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(r => r.Name)
            .WithErrorMessage(string.Format(
                ResourceExceptionMessages.NameLengthMessage,
                FieldValidation.NameMinLength,
                FieldValidation.NameMaxLength));
    }
}