using Domain.Common;

namespace Domain.Entities;

public sealed class Category : BaseEntity
{
    public ICollection<Product> Products { get; private set; } = [];
    
    public Category(string name) : base(name)
    {
    }
}