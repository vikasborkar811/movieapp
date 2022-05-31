using Microsoft.EntityFrameworkCore;
using MovieApp.Entity;

namespace MovieApp.Data.DataConnection
{
    public class MovieDBContext : DbContext
    {

        public MovieDBContext(DbContextOptions<MovieDBContext> options) : base(options)
        {

        }

        public DbSet<UserModel> userModels { get; set; }
        
        public DbSet<MovieModel> movieModels { get; set; }

        public DbSet<TheatreModel> theatreModels { get; set; }
    }
}