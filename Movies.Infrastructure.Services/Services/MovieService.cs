using Movies.Domain.Models;
using Movies.Domain.Services;
using Movies.Infrastructure.Context;
using System;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Services.Services
{
    public class MovieService : IMovieService
    {
        private readonly ApplicationDbContext _dbContext;

        public MovieService(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public Task<MovieModel> CreateMovie(MovieModel newMovie)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteMovie(string movieId)
        {
            throw new NotImplementedException();
        }

        public Task<MovieModel> FetchMovie(string movieId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateMovie(MovieModel updatedMovie)
        {
            throw new NotImplementedException();
        }
    }
}
