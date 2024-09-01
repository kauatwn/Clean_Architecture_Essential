using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext DbContext { get; }

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task CommitAsync()
        {
            await DbContext.SaveChangesAsync();
        }
    }
}
