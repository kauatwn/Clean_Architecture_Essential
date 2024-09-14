using Domain.Entities;
using Domain.Interfaces.Repositories.Category;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class CategoryRepository(ApplicationDbContext dbContext)
    : ICategoryReadOnlyRepository, ICategoryWriteOnlyRepository
{
    private ApplicationDbContext DbContext { get; } = dbContext;

    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await DbContext.Categories.AnyAsync(c => c.Name == name);
    }

    public async Task AddAsync(Category category)
    {
        await DbContext.Categories.AddAsync(category);
    }
}