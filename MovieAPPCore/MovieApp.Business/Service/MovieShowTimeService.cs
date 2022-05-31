using MovieApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Business.Service
{
    public class MovieShowTimeService
    {
        IMovieShowTime _movieShowTime;
        public MovieShowTimeService(IMovieShowTime movieShowTime)
        {
            _movieShowTime = movieShowTime;
        }
        public string InsertMovieShowTime(MovieApp.Entity.MovieShowTime movieShowTime)
        {
            return _movieShowTime.InsertMovieShowTime(movieShowTime);
        }
        public List<MovieApp.Entity.MovieShowTime> ShowMovieTimeList()
        {
            return _movieShowTime.ShowMovieShowTime();
        }

        public object findMovieShowTimeById(int movieshowTimeId)
        {
            return _movieShowTime.findMovieShowTimeById(movieshowTimeId);
        }

        public string UpdateMovieShowTime(Entity.MovieShowTime movieShowTime)
        {
            return _movieShowTime.UpdateMovieShowTime(movieShowTime);
        }
    }
}
