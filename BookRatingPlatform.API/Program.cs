using BookRatingPlatform.API.Extensions;
using BookRatingPlatform.BLL.Mappers;
using BookRatingPlatform.DAL.Interfaces;
using BookRatingPlatform.DAL.Models;
using BookRatingPlatform.DAL.Repositories;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;

namespace BookRatingPlatform.API;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        IServiceCollection services = builder.Services;

        services.AddDbContext<ApplicationDbContext>(opts => 
            opts.UseInMemoryDatabase("BookRatingPlatformDB"));

        services.ConfigureCors();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.ConfigureEntityServices();

        services.AddAutoMapper(typeof(BookMappingProfile),
            typeof(RatingMappingProfile),
            typeof(ReviewMappingProfile));

        services.AddControllers()
            .AddNewtonsoftJson();
        services.AddEndpointsApiExplorer();

        services.ConfigureFluentValidation();

        services.AddSwaggerGen();

        var app = builder.Build();

        await app.SeedData();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI();
        }
        else
        {
            app.ConfigureExceptionHandler();
        }

        app.UseHttpsRedirection();

        app.UseCors("CorsPolicy");

        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.All
        });

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
