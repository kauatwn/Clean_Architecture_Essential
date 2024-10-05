using System.Net;
using Domain.Exceptions.Base;

namespace Domain.Exceptions;

public sealed class ResourceNotFoundException(string errorMessage) : DomainException(errorMessage)
{
    public override int StatusCode => (int)HttpStatusCode.NotFound;
}