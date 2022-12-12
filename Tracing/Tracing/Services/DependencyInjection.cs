using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Tracing.Services.implementation;
using Tracing.Services.interfaces;

namespace Tracing.Services;

public static class DependencyInjection
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo {Title = "Tracing Api", Version = "v1"});
            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
            {
                In = ParameterLocation.Header,
                Description = "Standard Authorization header using Bearer Scheme (\"bearer {token}\")",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey, 
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });

            options.OperationFilter<SecurityRequirementsOperationFilter>();
        });

        services.AddAutoMapper(typeof(Program).Assembly);
        services.AddScoped<IAuthentication, Authentication>();
        services.AddScoped<IComponentsService, ComponentsService>();
        services.AddScoped<IBikeService, BikeService>();
        services.AddScoped<IEmailService, EmailService>();
     
        return services;
    }
}