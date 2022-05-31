using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Data.Repositories;
using MovieApp.Entity;

namespace MovieApp.Business.Service
{
    public class TheatreService
    {
        ITheatre _iTheatre;

        public TheatreService(ITheatre iTheatre)
        {
            _iTheatre = iTheatre;
        }

        public string AddThetre(TheatreModel theatreModel)
        {
            return _iTheatre.AddThetre(theatreModel);

        }

        public Object SelectThetre()
        {
            return _iTheatre.SelectThetre();
        }

        public object findTheatreById(int id)
        {
            return _iTheatre.findTheatreById(id);
        }

        public string UpdateTheatre(TheatreModel theatreModel)
        {
            return _iTheatre.Update(theatreModel);
        }


        public string DeleteTheatre(int id)
        {
            return _iTheatre.Delete(id);
        }
    }
}
