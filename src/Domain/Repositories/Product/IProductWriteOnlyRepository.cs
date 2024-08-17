namespace Domain.Repositories.Product
{
    public interface IProductWriteOnlyRepository
    {
        Task AddAsync(Entities.Product product);
    }
}
