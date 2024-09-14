namespace Application.DTOs.Responses.Product;

public sealed record CreateProductResponse(int Id, string Name, string Description, int CategoryId);