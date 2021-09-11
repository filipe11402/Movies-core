﻿using Movies.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Services
{
    public interface IMovieService
    {
        Task<MovieCreationStatusModel> CreateMovie(MovieModel newMovie);
        Task<bool> UpdateMovie(MovieModel updatedMovie);
        Task<bool> DeleteMovie(string movieId);
        Task<MovieModel> FetchMovie(string movieId);
    }
}
