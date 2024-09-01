using Domain.Entities;
using Domain.Interfaces.Repositories.Category;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryReadOnlyRepository, ICategoryWriteOnlyRepository
    {
        private ApplicationDbContext DbContext { get; }

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task AddAsync(Category category)
        {
            await DbContext.Categories.AddAsync(category);
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await DbContext.Categories.AnyAsync(c => c.Name == name);
        }
    }
}
