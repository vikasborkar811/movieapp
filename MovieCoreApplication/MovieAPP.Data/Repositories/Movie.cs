using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Data.DataConnection;
//using MovieApp.Entity;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MovieApp.Data.Repositories
{
    public class Movie : IMovie
    {
        MovieDBContext _movieDBContext;
        public Movie(MovieDBContext movieDBContext)
        {
            _movieDBContext = movieDBContext;
        }
        public void AddMovie(MovieModel movieModel)
        {
            
            _movieDBContext.movieModels.Add(movieModel);
            _movieDBContext.SaveChanges();
            
            
        }

        public MovieModel GetMovieById(int movieId)
        {
            var result = _movieDBContext.movieModels.Find(movieId);
            return result;
        }

        public object SelectMovie()
        {
            List<MovieModel> movieList = _movieDBContext.movieModels.ToList();
            return movieList;
        }

        public string DeleteMovie(int MovieId)
        {
            string message = "";
            var foundMovie = _movieDBContext.movieModels.Find(MovieId);
            if (foundMovie != null)
            {
                _movieDBContext.movieModels.Remove(foundMovie);
                _movieDBContext.SaveChanges();
                message = "Movie Deleted Successfully..!!";
                return message;
            }
            else
            {
                message = "Movie Deleted Successfully..!!";
                return message;
            }


        }

        public string Update(MovieModel movieModel)
        {
            _movieDBContext.Entry(movieModel).State = EntityState.Modified;
            _movieDBContext.SaveChanges();
            return "Data Upddated";
        }

       
    }
}
