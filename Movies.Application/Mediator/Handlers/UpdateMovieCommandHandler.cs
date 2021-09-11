using MediatR;
using Movies.Application.Mediator.Commands;
using Movies.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Application.Mediator.Handlers
{
    public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, bool>
    {
        private readonly IMovieService _movieService;

        public UpdateMovieCommandHandler(IMovieService movieService)
        {
            this._movieService = movieService;
        }

        public async Task<bool> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var response = await this._movieService.UpdateMovie(request.Movie);

            return response;
        }
    }
}
