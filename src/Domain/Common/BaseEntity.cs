﻿namespace Domain.Common;

public abstract class BaseEntity
{
    public int Id { get; protected set; }
    public string Name { get; protected set; }
    public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;

    protected BaseEntity(string name)
    {
        Name = name;
    }
}