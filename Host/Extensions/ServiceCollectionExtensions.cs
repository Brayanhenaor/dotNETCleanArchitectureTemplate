﻿using Application.Profiles;
using Application.Queries;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces.Services;
using Application.Interfaces.Api;
using Infrastructure.Api;
using Application.DTO.Response;
using Microsoft.AspNetCore.Mvc;
using Application.DTO;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces.Repositories;
using Infrastructure.Repositories;
using Infraestructure.UnitOfWork;
using Application.Interfaces.UnitOfWork;

namespace Host.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOpenApiConfig(this IServiceCollection services)
    {
        services.AddOpenApi();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }

    public static IServiceCollection AddCustomMvc(this IServiceCollection services)
    {
        services
            .AddMvc()
            .AddApplicationPart(typeof(ServiceCollectionExtensions).Assembly);

        services.AddControllers()
        .ConfigureApiBehaviorOptions(options =>
        {
            options.InvalidModelStateResponseFactory = context =>
            {
                var validationErrors = context.ModelState
                    .Where(ms => ms.Value?.Errors.Count > 0)
                    .Select(ms => new ValidationError
                    {
                        Key = ms.Key,
                        Error = string.Join(", ", ms.Value!.Errors.Select(e => e.ErrorMessage))
                    })
                    .ToList();

                var apiResponse = new ApiResponse<List<ValidationError>>
                {
                    Success = false,
                    Message = "One or more validation errors occurred.",
                    Result = validationErrors
                };

                return new BadRequestObjectResult(apiResponse);
            };
        })
        .AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        });

        services.AddEndpointsApiExplorer();

        return services;
    }

    public static IServiceCollection AddCustomHttpContext(this IServiceCollection services)
    {
        return services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }

    public static IServiceCollection AddInyectionDependency(this IServiceCollection services)
    {
        #region Services
        services.AddScoped<ISampleService, SampleService>();
        services.AddScoped<IApiService, ApiService>();
        #endregion

        #region Repositories
        services.AddScoped<ISampleRepository, SampleRepository>();
        #endregion

        #region UnitOfWork
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        #endregion

        return services;
    }

    public static IServiceCollection AddEntityFrameworkCore(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SampleDbContext>((serviceProvider, options) =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            options.UseSqlServer(connectionString)
                   .LogTo(Console.WriteLine)
                   .EnableSensitiveDataLogging();
        });

        return services;
    }

    public static IServiceCollection AddMediatRConfig(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetSampleQuery).Assembly));
        return services;
    }


    public static IServiceCollection AddAutomapperConfig(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(SampleProfile).Assembly);
        return services;
    }
}