using Domain.Interfaces;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence;

public class UnitOfWork(ApplicationDbContext dbContext) : IUnitOfWork
{
    private ApplicationDbContext DbContext { get; } = dbContext;

    public async Task CommitAsync()
    {
        await DbContext.SaveChangesAsync();
    }
}