using Bogus;
using Domain.Entities;
using FluentAssertions;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.IntegrationTests.Persistence.Repositories;

public class CategoryRepositoryTest
{
    private ApplicationDbContext DbContext { get; }
    private CategoryRepository CategoryRepository { get; }
    private UnitOfWork UnitOfWork { get; }

    private Faker<Category> CategoryFaker { get; } = new Faker<Category>().CustomInstantiator(f =>
        new Category(f.Commerce.Department(), f.Commerce.ProductDescription()));

    public CategoryRepositoryTest()
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();

        var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite(connection).Options;

        DbContext = new ApplicationDbContext(options);
        DbContext.Database.EnsureCreated();

        CategoryRepository = new CategoryRepository(DbContext);
        UnitOfWork = new UnitOfWork(DbContext);
    }

    [Fact]
    public async Task ShouldAddAsyncWhenCategoryIsValid()
    {
        // Arrange
        var category = CategoryFaker.Generate();

        // Act
        await CategoryRepository.AddAsync(category);
        await UnitOfWork.CommitAsync();

        // Assert
        var result = await DbContext.Categories.FindAsync(category.Id);
        result.Should().BeEquivalentTo(category);
    }

    [Fact]
    public async Task ShouldThrowDbUpdateExceptionWhenCategoryNameIsDuplicated()
    {
        // Arrange
        var category1 = CategoryFaker.Generate();

        // Act
        await CategoryRepository.AddAsync(category1);
        await UnitOfWork.CommitAsync();

        await CategoryRepository.AddAsync(category1);
        var act = async () => await UnitOfWork.CommitAsync();

        // Assert
        await act.Should().ThrowAsync<DbUpdateException>();
    }

    [Fact]
    public async Task ShouldReturnTrueWhenCategoryNameExists()
    {
        // Arrange
        var category = CategoryFaker.Generate();

        await CategoryRepository.AddAsync(category);
        await UnitOfWork.CommitAsync();

        // Act
        var categoryExists = await CategoryRepository.ExistsByNameAsync(category.Name);

        // Assert
        categoryExists.Should().BeTrue();
    }

    [Fact]
    public async Task ShouldReturnFalseWhenCategoryNamesDoesNotExist()
    {
        // Arrange
        var category = CategoryFaker.Generate();

        // Act
        var categoryExists = await CategoryRepository.ExistsByNameAsync(category.Name);

        // Assert
        categoryExists.Should().BeFalse();
    }
}