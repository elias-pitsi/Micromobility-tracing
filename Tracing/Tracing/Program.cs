using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Tracing.Configurations;
using Tracing.DataAccess.DataContext;
using Tracing.DataAccess.Models;
using Tracing.Services;


var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.RegisterServices();
    builder.Services.AddControllers();
    builder.Services.AddControllers(options =>
    {
        options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
    });

    builder.Services.AddSingleton<IDocumentClient>(_ =>
            new DocumentClient(new Uri(builder.Configuration["CosmosDB:AccountUrl"]), builder.Configuration["CosmosDB:PrimaryKey"]));

    builder.Services.AddDbContext<TracingContext>(options => options.UseCosmos(builder.Configuration["CosmosDB:DefaultConnection"], "Tracing"));

    builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection(JwtSettings.SectionName));
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("ReactNativeApp", policy =>
        {
            policy.AllowAnyOrigin();
        });
    });

    var TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
       // ValidIssuer = builder.Configuration.GetSection("JwtConfig:Issuer").Value,
        //ValidAudience = builder.Configuration.GetSection("JwtConfig:Audience").Value,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JwtConfig:Token").Value))
    };

    builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.TokenValidationParameters = TokenValidationParameters;
    });

    builder.Services.Configure<IdentityOptions>(options =>
    {
        // password settings
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequireUppercase = true;
        options.Password.RequiredLength = 8;
        options.Password.RequiredUniqueChars = 1;
    });
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseCors("ReactNativeApp");
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();

}
