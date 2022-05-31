using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Entity;

namespace MovieApp.Data.Repositories
{
    public interface ITheatre
    {
        string AddThetre(TheatreModel theatreModel);

        object SelectThetre();
        string Delete(int theatreId);
        string Update(TheatreModel theatreModel);
        public object findTheatreById(int id);

    }
}
