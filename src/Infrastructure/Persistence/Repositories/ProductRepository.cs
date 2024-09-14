using Domain.Entities;
using Domain.Interfaces.Repositories.Product;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Repositories;

public class ProductRepository(ApplicationDbContext context)
    : IProductReadOnlyRepository, IProductWriteOnlyRepository
{
    private ApplicationDbContext DbContext { get; } = context;

    public async Task AddAsync(Product product)
    {
        await DbContext.Products.AddAsync(product);
    }
}