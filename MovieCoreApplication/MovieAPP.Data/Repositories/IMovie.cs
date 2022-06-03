using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Entity;

namespace MovieApp.Data.Repositories
{
    public interface IMovie
    {
        void AddMovie(MovieModel movieModel);
        MovieModel GetMovieById(int movieId);
        string DeleteMovie(int MovieId);
        string Update(MovieModel movieModel);
        object SelectMovie();
    }
}
