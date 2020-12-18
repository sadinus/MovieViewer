using MovieViewer.Web.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieViewer.Web.Infrastructure.Repositories
{
    public interface IMovieVoteRepository
    {
        void Vote(MovieVote vote);
        double GetMovieGrade(int id);
    }
}
