namespace Domain.Repositories.Category
{
    public interface ICategoryWriteOnlyRepository
    {
        Task AddAsync(Entities.Category category);
    }
}
