using MovieViewer.Web.Infrastructure.Context;
using MovieViewer.Web.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieViewer.Web.Infrastructure.Repositories
{
    public class MovieVoteRepository : IMovieVoteRepository
    {
        private readonly MovieViewerContext _dbContext;
        public MovieVoteRepository(MovieViewerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Vote(MovieVote vote)
        {
            _dbContext.MovieGrades.Add(vote);
            _dbContext.SaveChanges();
        }

        public double GetMovieGrade(int id)
        {
            var numberOfVotes = _dbContext.MovieGrades.Where(x => x.MovieId == id).Count();
            
            if (numberOfVotes > 0)
            {
                return _dbContext.MovieGrades.Where(x => x.MovieId == id).Average(x => x.Value);
            }
            else
            {
                return 0;
            }
        }
    }
}
