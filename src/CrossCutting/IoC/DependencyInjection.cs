using Application.Abstractions.Mappings;
using Application.Abstractions.UseCases.Category;
using Application.Abstractions.UseCases.Product;
using Application.DTOs.Requests.Category;
using Application.DTOs.Requests.Product;
using Application.Mappings.Category;
using Application.Mappings.Product;
using Application.UseCases.Category.Create;
using Application.UseCases.Product.Create;
using Domain.Interfaces;
using Domain.Interfaces.Repositories.Category;
using Domain.Interfaces.Repositories.Product;
using FluentValidation;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.IoC;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddValidators(services);
        AddMappings(services);
        AddUseCases(services);
    }

    public static void AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        AddDbContext(services, config);
        AddRepositories(services);
    }

    private static void AddValidators(IServiceCollection services)
    {
        services.AddScoped<IValidator<CreateCategoryRequest>, CreateCategoryValidator>();
        services.AddScoped<IValidator<CreateProductRequest>, CreateProductValidator>();
    }

    private static void AddMappings(IServiceCollection services)
    {
        services.AddTransient<ICategoryMapper, CategoryMapper>();
        services.AddTransient<IProductMapper, ProductMapper>();
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<ICreateCategoryUseCase, CreateCategoryUseCase>();
        services.AddScoped<ICreateProductUseCase, CreateProductUseCase>();
    }

    private static void AddDbContext(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(config.GetConnectionString("DefaultConnection"),
                builder => { builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName); });
        });
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<ICategoryWriteOnlyRepository, CategoryRepository>();

        services.AddScoped<IProductWriteOnlyRepository, ProductRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}