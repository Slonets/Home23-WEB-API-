using DateAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateAccess.Data
{
    public class CinemaDbContext:DbContext
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options):base(options) 
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedMovies();
            modelBuilder.SeedGanre();
            modelBuilder.SeedMovieGanre();
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Ganre> Ganres { get; set; }
        public DbSet<MovieGanre> MovieGanres { get; set; }
    }
}
