using Application.Shared.Resources;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace API.Middleware;

public class ExceptionHandlerMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var problemDetails = exception switch
        {
            ErrorOnValidationException validationException => new ProblemDetails
            {
                Status = validationException.StatusCode,
                Title = ResourceExceptionMessages.ValidationErrorTitle,
                Detail = validationException.Message,
                Instance = context.Request.Path.Value
            },
            ResourceNotFoundException resourceNotFoundException => new ProblemDetails
            {
                Status = resourceNotFoundException.StatusCode,
                Title = ResourceExceptionMessages.ResourceNotFoundTitle,
                Detail = resourceNotFoundException.Message,
                Instance = context.Request.Path.Value
            },
            _ => new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = ResourceExceptionMessages.UnknownErrorTitle,
                Detail = ResourceExceptionMessages.UnknownErrorMessage,
                Instance = context.Request.Path.Value
            }
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = problemDetails.Status ?? StatusCodes.Status500InternalServerError;
        await context.Response.WriteAsJsonAsync(problemDetails);
    }
}