using System.Net;
using Domain.Exceptions.Base;

namespace Domain.Exceptions;

public sealed class ErrorOnValidationException(IList<string> errors)
    : DomainException("The request was not processed due to one or more validation errors")
{
    public IList<string> Errors { get; } = errors;

    public override int StatusCode => (int)HttpStatusCode.UnprocessableEntity;
}