using Microsoft.EntityFrameworkCore;
using MovieApp.Data.DataConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieApp.Data.Repositories
{
    public class MovieShowTime : IMovieShowTime
    {
        MovieDBContext _movieDbContext;
        public MovieShowTime(MovieDBContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public object findMovieShowTimeById(int movieShowTimeId)
        {
            var foundUser = _movieDbContext.movieShowTimes.Find(movieShowTimeId);
            if (foundUser != null)
            {
                return foundUser;
            }
            else
            {
                return "User not Found..!!";
            }
        }

        public string InsertMovieShowTime(MovieApp.Entity.MovieShowTime movieShowTime)
        {
            _movieDbContext.movieShowTimes.Add(movieShowTime);
            _movieDbContext.SaveChanges();
            return "Inserted";
        }

        public List<MovieApp.Entity.MovieShowTime> ShowMovieShowTime()
        {
            return _movieDbContext.movieShowTimes.ToList();
        }
        public string UpdateMovieShowTime(Entity.MovieShowTime movieShowTime)
        {
            _movieDbContext.Entry(movieShowTime).State = EntityState.Modified;
            _movieDbContext.SaveChanges();
            return "Data Upddated";
        }
    }
}
