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
    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, bool>
    {
        private readonly IMovieService _movieService;

        public DeleteMovieCommandHandler(IMovieService movieService)
        {
            this._movieService = movieService;
        }

        public async Task<bool> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            return await this._movieService.DeleteMovie(request.Id);
        }
    }
}
