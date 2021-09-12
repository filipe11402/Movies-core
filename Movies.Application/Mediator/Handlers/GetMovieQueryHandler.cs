using AutoMapper;
using MediatR;
using Movies.Application.Mediator.Queries;
using Movies.Application.Models.Movies;
using Movies.Domain.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Application.Mediator.Handlers
{
    public class GetMovieQueryHandler : IRequestHandler<GetMovieQuery, MovieViewModel>
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public GetMovieQueryHandler(IMovieService movieService, IMapper mapper)
        {
            this._movieService = movieService;
            this._mapper = mapper;
        }

        public async Task<MovieViewModel> Handle(GetMovieQuery request, CancellationToken cancellationToken)
        {
            var movie = await this._movieService.FetchMovie(request.Id);

            return this._mapper.Map<MovieViewModel>(movie);
        }
    }
}
