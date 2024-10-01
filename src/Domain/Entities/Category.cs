using Domain.Common;

namespace Domain.Entities;

public sealed class Category : BaseEntity
{
    public ICollection<Product> Products { get; private set; } = [];

    public Category(int id, string name, string description) : base(id, name, description)
    {
    }

    public Category(string name, string description) : base(name, description)
    {
    }
}