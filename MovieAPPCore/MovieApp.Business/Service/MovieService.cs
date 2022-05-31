using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Data.Repositories;
using MovieApp.Entity;

namespace MovieApp.Business.Service
{
    public class MovieService
    {
        IMovie _imovie;
        public MovieService(IMovie imovie)
        {
            _imovie = imovie;
        }

        public void AddMovie(MovieModel movieModel)
        {
           _imovie.AddMovie(movieModel);          
        }

        public MovieModel GetMovieById(int movieId)
        {
            return _imovie.GetMovieById(movieId);
        }

        public object SelectMovie()
        {
            return _imovie.SelectMovie();
        }

        public string DeleteMovie(int id)
        {
            return _imovie.DeleteMovie(id);
        }

        public string UpdateMovie(MovieModel movieModel)
        {
            return _imovie.Update(movieModel);
        }

        public object findMovieById(int id)
        {
            return _imovie.GetMovieById(id);
        }
    }
}
