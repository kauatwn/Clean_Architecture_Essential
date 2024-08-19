using Domain.Common;

namespace Domain.Entities
{
    public sealed class Category : BaseEntity
    {
        public IReadOnlyCollection<Product> Products { get; } = [];

        public Category(string name, string? imageUrl = null) : base(name, imageUrl) { }
    }
}
