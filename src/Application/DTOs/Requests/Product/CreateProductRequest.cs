namespace Application.DTOs.Requests.Product;

public sealed record CreateProductRequest(string Name, string Description, decimal Price, int Stock, int CategoryId);