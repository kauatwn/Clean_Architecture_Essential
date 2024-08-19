namespace Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string? ImageUrl { get; protected set; }
        public DateTime CreatedOn { get; protected set; } = DateTime.UtcNow;

        protected BaseEntity(string name, string? imageUrl)
        {
            Name = name;
            ImageUrl = imageUrl;
        }
    }
}
