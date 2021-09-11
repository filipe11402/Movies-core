using AutoMapper;
using MediatR;
using Movies.Application.Mediator.Queries;
using Movies.Application.Models.Movies;
using Movies.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Application.Mediator.Handlers
{
    public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, IEnumerable<MovieViewModel>>
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public GetMoviesQueryHandler(IMovieService movieService, IMapper mapper)
        {
            this._movieService = movieService;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<MovieViewModel>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
        {
            var moviesList = await this._movieService.FetchMovies();

            return this._mapper.Map<IEnumerable<MovieViewModel>>(moviesList);
        }
    }
}
