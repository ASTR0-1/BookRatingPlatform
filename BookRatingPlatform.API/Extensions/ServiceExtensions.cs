using System.Net;
using BookRatingPlatform.BLL.DataSeeding;
using BookRatingPlatform.BLL.DTO;
using BookRatingPlatform.BLL.Interfaces;
using BookRatingPlatform.BLL.Services;
using BookRatingPlatform.BLL.Validation;
using BookRatingPlatform.DAL.Models;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;

namespace BookRatingPlatform.API.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(opts =>
        {
            opts.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyHeader()
                .AllowAnyMethod()
                .WithOrigins("http://localhost:4200")
                .AllowCredentials());
        });

    public static void ConfigureEntityServices(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IRatingService, RatingService>();
        services.AddScoped<IReviewService, ReviewService>();
    }

    public static void ConfigureFluentValidation(this IServiceCollection services)
    {
        services.AddScoped<IValidator<BookForCreationDto>, BookForCreationDtoValidator>();
        services.AddScoped<IValidator<RatingForAddingDto>, RatingForAddingDtoValidator>();
        services.AddScoped<IValidator<ReviewForAddingDto>, ReviewForAddingDtoValidator>();
    }

    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    await context.Response.WriteAsync(new
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = "Internal Server Error."
                    }.ToString());
                }
            });
        });
    }

    public static void SeedData(this IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetService<ApplicationDbContext>();

            var books = BookDataSeed.SeedBook();
            var ratings = RatingDataSeed.SeedRating();
            var reviews = ReviewDataSeed.SeedReview();

            context.Books.AddRange(books);
            context.Reviews.AddRange(reviews);
            context.Ratings.AddRange(ratings);

            context.SaveChanges();
        }
    }
}
