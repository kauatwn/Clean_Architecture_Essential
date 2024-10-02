namespace Domain.Exceptions.Base;

public abstract class DomainException(string errorMessage) : Exception(errorMessage)
{
    public abstract int StatusCode { get; }
}