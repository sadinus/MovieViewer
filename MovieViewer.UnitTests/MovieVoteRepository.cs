using Microsoft.EntityFrameworkCore;
using Moq;
using MovieViewer.Web.Infrastructure.Context;
using MovieViewer.Web.Infrastructure.Entities;
using MovieViewer.Web.Infrastructure.Repositories;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace MovieViewer.UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Test1()
        {
            var movieId = 1;
            var votes = new List<MovieVote>
            {
                new MovieVote { Id = 1, MovieId = 1, Value = 1 },
                new MovieVote { Id = 2, MovieId = 1, Value = 2 },
                new MovieVote { Id = 3, MovieId = 1, Value = 6 },
                new MovieVote { Id = 4, MovieId = 2, Value = 9 },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<MovieVote>>();
            mockSet.As<IQueryable<MovieVote>>().Setup(m => m.Provider).Returns(votes.Provider);
            mockSet.As<IQueryable<MovieVote>>().Setup(m => m.Expression).Returns(votes.Expression);
            mockSet.As<IQueryable<MovieVote>>().Setup(m => m.ElementType).Returns(votes.ElementType);
            mockSet.As<IQueryable<MovieVote>>().Setup(m => m.GetEnumerator()).Returns(votes.GetEnumerator());

            var mockContext = new Mock<MovieViewerContext>();
            mockContext.Setup(c => c.MovieGrades).Returns(mockSet.Object);

            var repository = new MovieVoteRepository(mockContext.Object);
            var grade = repository.GetMovieGrade(movieId);

            Assert.AreEqual(3, grade);
        }
    }
}