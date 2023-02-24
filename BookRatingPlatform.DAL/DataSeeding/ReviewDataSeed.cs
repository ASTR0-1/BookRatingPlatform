using BookRatingPlatform.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookRatingPlatform.BLL.DataSeeding;

public class ReviewDataSeed
{
    public static Review[] SeedReview()
    {
        var reviews = new Review[]
        {
            new Review()
            {
                Id = 1,
                BookId = 1,
                Message = "This book was amazing!",
                Reviewer = "John Doe"
            },

            new Review()
            {
                Id = 2,
                BookId = 1,
                Message = "I couldn't put this book down!",
                Reviewer = "Jane Smith"
            },

            new Review()
            {
                Id = 3,
                BookId = 1,
                Message = "The characters were so well-developed!",
                Reviewer = "Bob Johnson"
            },

            new Review()
            {
                Id = 4,
                BookId = 1,
                Message = "This book changed my life!",
                Reviewer = "Alice Lee"
            },

            new Review()
            {
                Id = 5,
                BookId = 1,
                Message = "I loved the setting of this book!",
                Reviewer = "David Kim"
            },

            new Review()
            {
                Id = 6,
                BookId = 1,
                Message = "I would recommend this book to everyone!",
                Reviewer = "Emily Liu"
            },

            new Review()
            {
                Id = 7,
                BookId = 1,
                Message = "The plot twists in this book were amazing!",
                Reviewer = "Jessica Wang"
            },

            new Review()
            {
                Id = 8,
                BookId = 1,
                Message = "The writing in this book was beautiful!",
                Reviewer = "Daniel Kim"
            },

            new Review()
            {
                Id = 9,
                BookId = 1,
                Message = "I couldn't predict the ending of this book!",
                Reviewer = "Michael Johnson"
            },

            new Review()
            {
                Id = 10,
                BookId = 1,
                Message = "This book was such a page-turner!",
                Reviewer = "Rachel Lee"
            },

            new Review()
            {
                Id = 11,
                BookId = 1,
                Message = "The themes in this book were so relevant!",
                Reviewer = "Alex Rodriguez"
            },

            new Review()
            {
                Id = 12,
                BookId = 7,
                Message = "I loved the characters in this book!",
                Reviewer = "William Chen"
            },

            new Review()
            {
                Id = 13,
                BookId = 10,
                Message = "I couldn't stop thinking about this book!",
                Reviewer = "Jessica Wang"
            },

            new Review()
            {
                Id = 14,
                BookId = 2,
                Message = "The descriptions in this book were so vivid!",
                Reviewer = "David Kim"
            },

            new Review()
            {
                Id = 15,
                BookId = 5,
                Message = "This book was so heartwarming!",
                Reviewer = "Emily Liu"
            },

            new Review()
            {
                Id = 16,
                BookId = 4,
                Message = "I was hooked from the first page of this book!",
                Reviewer = "Michael Johnson"
            },

            new Review()
            {
                Id = 17,
                BookId = 9,
                Message = "This book had such an interesting premise!",
                Reviewer = "Bob Johnson"
            },

            new Review()
            {
                Id = 18,
                BookId = 6,
                Message = "The pacing of this book was perfect!",
                Reviewer = "Alice Lee"
            },

            new Review()
            {
                Id = 19,
                BookId = 10,
                Message = "The worldbuilding in this book was amazing!",
                Reviewer = "John Doe"
            },

            new Review()
            {
                Id = 20,
                BookId = 8,
                Message = "This book made me laugh and cry!",
                Reviewer = "Jane Smith"
            }
        };

        return reviews;
    }
}
