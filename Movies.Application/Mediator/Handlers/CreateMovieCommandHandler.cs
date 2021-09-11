using AutoMapper;
using MediatR;
using Movies.Application.Mediator.Commands;
using Movies.Application.Models.Movies;
using Movies.Domain.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Application.Mediator.Handlers
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, CreateMovieViewModel>
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public CreateMovieCommandHandler(IMovieService movieService, IMapper mapper)
        {
            this._movieService = movieService;
            this._mapper = mapper;
        }

        public async Task<CreateMovieViewModel> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var creationResponse = await this._movieService.CreateMovie(request.Movie);

            var returnData = this._mapper.Map<CreateMovieViewModel>(creationResponse);

            return returnData;
        }
    }
}
