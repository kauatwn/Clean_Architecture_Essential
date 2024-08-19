namespace Domain.Interfaces.Repositories.Product
{
    public interface IProductWriteOnlyRepository
    {
        Task AddAsync(Entities.Product product);
    }
}
