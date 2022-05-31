using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Entity;

namespace MovieApp.Data.Repositories
{
    public interface IMovieShowTime
    {
        string InsertMovieShowTime(MovieApp.Entity.MovieShowTime movieShowTime);
        List<MovieApp.Entity.MovieShowTime> ShowMovieShowTime();

        public object findMovieShowTimeById(int movieShowTimeId);

       
        string UpdateMovieShowTime(Entity.MovieShowTime movieShowTime);
    }
}
