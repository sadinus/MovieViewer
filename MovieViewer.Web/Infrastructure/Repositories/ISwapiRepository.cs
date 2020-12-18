using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieViewer.Web.Infrastructure.Repositories
{
    public interface ISwapiRepository
    {
        Task<SwapiResponse> GetMovies();
    }
}
