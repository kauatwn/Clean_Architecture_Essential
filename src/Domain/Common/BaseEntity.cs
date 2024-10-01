namespace Domain.Common;

public abstract class BaseEntity(string name, string description)
{
    public int Id { get; protected set; }
    public string Name { get; protected set; } = name;
    public string Description { get; protected set; } = description;
    public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;

    protected BaseEntity(int id, string name, string description) : this(name, description)
    {
        Id = id;
    }
}