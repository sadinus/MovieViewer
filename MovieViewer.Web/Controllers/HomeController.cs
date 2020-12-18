using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieViewer.Web.Infrastructure.Entities;
using MovieViewer.Web.Infrastructure.Repositories;
using MovieViewer.Web.Models;

namespace MovieViewer.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISwapiRepository _swapiRepository;
        private readonly IMovieVoteRepository _movieVoteRepository;

        public HomeController(ILogger<HomeController> logger, ISwapiRepository swapiRepository, IMovieVoteRepository movieVoteRepository)
        {
            _logger = logger;
            _swapiRepository = swapiRepository;
            _movieVoteRepository = movieVoteRepository;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _swapiRepository.GetMovies();

            IEnumerable<MovieDto> movies = response.results.Select(m => new MovieDto() {
                Id = m.episode_id,
                Title = m.title,
                Description = $"Director: {m.director}, Release Date: {m.release_date}, Producer: {m.producer}",
                Grade = _movieVoteRepository.GetMovieGrade(m.episode_id)
            });

            return View(movies);
        }

        public IActionResult Vote(int movieId, int vote)
        {
            var grade = new MovieVote()
            {
                MovieId = movieId,
                Value = vote
            };
            _movieVoteRepository.Vote(grade);
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
