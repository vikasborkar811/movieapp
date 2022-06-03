using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Data.DataConnection;
using MovieApp.Entity;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace MovieApp.Data.Repositories
{
    public class Theatre : ITheatre
    {
        MovieDBContext _movieDBContext;

        public Theatre(MovieDBContext movieDBContext)
        {
            _movieDBContext = movieDBContext;
        }

        public string AddThetre(TheatreModel theatreModel)
        {
            string message = "";
            _movieDBContext.theatreModels.Add(theatreModel);
            _movieDBContext.SaveChanges();
            message = "Thetre Added Successfully..!!";
            return message;
        }

        public string Delete(int theatreId)
        {
            string message = "";
            var foundUser = _movieDBContext.theatreModels.Find(theatreId);
            if (foundUser != null)
            {
                _movieDBContext.theatreModels.Remove(foundUser);
                _movieDBContext.SaveChanges();
                message = "Theatre Deleted Successfully..!!";
                return message;
            }
            else
            {
                message = "User Not Found..!!";
                return message;
            }
        }

        public object findTheatreById(int id)
        {
            var foundUser = _movieDBContext.theatreModels.Find(id);
            if (foundUser != null)
            {
                return foundUser;
            }
            else
            {
                return "Theatre not Found..!!";
            }
        }

        public object SelectTheatre()
        {
            List<TheatreModel> theatreList = _movieDBContext.theatreModels.ToList();
            return theatreList;
        }

        public string Update(TheatreModel theatreModel)
        {
            _movieDBContext.Entry(theatreModel).State = EntityState.Modified;
            _movieDBContext.SaveChanges();
            return "Data Upddated";
        }
    }
}
