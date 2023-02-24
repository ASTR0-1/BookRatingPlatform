using BookRatingPlatform.DAL.Models;

namespace BookRatingPlatform.BLL.DataSeeding;

public class RatingDataSeed
{
    public static List<Rating> SeedRating()
    {
        var ratings = new List<Rating>
        {
            new Rating() { Id = 1, BookId = 3, BookRating = 4.2m },

            new Rating() { Id = 2, BookId = 7, BookRating = 2.7m },

            new Rating() { Id = 3, BookId = 8, BookRating = 4.9m },

            new Rating() { Id = 4, BookId = 10, BookRating = 3.5m },

            new Rating() { Id = 5, BookId = 2, BookRating = 2.8m },

            new Rating() { Id = 6, BookId = 9, BookRating = 4.1m },

            new Rating() { Id = 7, BookId = 5, BookRating = 3.7m },

            new Rating() { Id = 8, BookId = 4, BookRating = 4.8m },

            new Rating() { Id = 9, BookId = 6, BookRating = 2.5m },

            new Rating() { Id = 10, BookId = 3, BookRating = 3.9m },

            new Rating() { Id = 11, BookId = 7, BookRating = 4.7m },

            new Rating() { Id = 12, BookId = 1, BookRating = 2.1m },

            new Rating() { Id = 13, BookId = 8, BookRating = 3.6m },

            new Rating() { Id = 14, BookId = 2, BookRating = 4.3m },

            new Rating() { Id = 15, BookId = 5, BookRating = 1.9m },

            new Rating() { Id = 16, BookId = 4, BookRating = 3.8m },

            new Rating() { Id = 17, BookId = 10, BookRating = 4.5m },

            new Rating() { Id = 18, BookId = 6, BookRating = 2.2m },

            new Rating() { Id = 19, BookId = 9, BookRating = 3.1m },

            new Rating() { Id = 20, BookId = 1, BookRating = 4.6m }
        };

        return ratings;
    }
}
