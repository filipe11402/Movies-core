using MediatR;
using Movies.Domain.Models;

namespace Movies.Application.Mediator.Commands
{
    public class UpdateMovieCommand : IRequest<bool>
    {
        public MovieModel Movie { get; }

        public UpdateMovieCommand(MovieModel updatedMovie)
        {
            this.Movie = updatedMovie;
        }
    }
}
