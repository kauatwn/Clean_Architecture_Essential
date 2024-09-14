namespace Domain.Interfaces.Repositories.Category;

public interface ICategoryWriteOnlyRepository
{
    Task AddAsync(Entities.Category category);
}