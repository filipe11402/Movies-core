using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Movies.Domain.Models;
using Movies.Domain.Services;
using Movies.Infrastructure.Context;
using Movies.Infrastructure.Entities;
using System;
using System.Collections.Generic;
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

        public async Task<bool> DeleteMovie(string movieId)
        {
            var movie = await this._dbContext.Movies
                                    .FirstOrDefaultAsync(token => token.Id == movieId);

            if (movie == null) 
            {
                return false;
            }

            this._dbContext.Movies.Remove(movie);

            await this._dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<MovieModel> FetchMovie(string movieId)
        {
            var movie = await this._dbContext.Movies
                                                .FirstOrDefaultAsync(token => token.Id == movieId);

            return this._mapper.Map<MovieModel>(movie);
        }

        public async Task<IEnumerable<MovieModel>> FetchMovies()
        {
            return this._mapper.Map<IEnumerable<MovieModel>>(this._dbContext.Movies);
        }

        public async Task<bool> UpdateMovie(MovieModel updatedMovie)
        {
            var exists = await this._dbContext.Movies.FirstOrDefaultAsync(token => token.Id == updatedMovie.Id);

            if (exists == null) 
            {
                return false;
            }

            exists.Name = updatedMovie.Name;
            exists.ReleaseYear = updatedMovie.ReleaseYear;

            var response = this._dbContext.Movies.Update(exists);

            await this._dbContext.SaveChangesAsync();

            return true;
        }
    }
}
