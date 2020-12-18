using Microsoft.EntityFrameworkCore;
using MovieViewer.Web.Infrastructure.Entities;

namespace MovieViewer.Web.Infrastructure.Context
{
    public class MovieViewerContext : DbContext
    {
        public MovieViewerContext(DbContextOptions<MovieViewerContext> options) : base(options)
        {
        }

        public MovieViewerContext() : base()
        {
        }

        public virtual DbSet<MovieVote> MovieGrades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieVote>().ToTable("MovieGrade");
        }

    }
}
