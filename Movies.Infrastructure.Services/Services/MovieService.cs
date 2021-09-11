using AutoMapper;
using Movies.Domain.Models;
using Movies.Domain.Services;
using Movies.Infrastructure.Context;
using Movies.Infrastructure.Entities;
using System;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Services.Services
{
    public class MovieService : IMovieService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public MovieService(ApplicationDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        public async Task<MovieCreationStatusModel> CreateMovie(MovieModel newMovie)
        {
            var returnModel = new MovieCreationStatusModel();

            var dbModel = this._mapper.Map<Movie>(newMovie);

            var response = await this._dbContext.Movies.AddAsync(dbModel);

            if (response == null) 
            {
                returnModel.Status = "error";

                return returnModel;
            }

            await this._dbContext.SaveChangesAsync();

            returnModel.Id = newMovie.Id;
            returnModel.Status = "created";

            return returnModel;
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
