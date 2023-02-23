using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookRatingPlatform.DAL.Models;
using BookRatingPlatform.DAL.Repositories;

namespace BookRatingPlatform.DAL.Interfaces;

public interface IUnitOfWork
{
    public BookRepository BookRepository { get; }

    public RatingRepository RatingRepository { get; }

    public ReviewRepository ReviewRepository { get; }
}
