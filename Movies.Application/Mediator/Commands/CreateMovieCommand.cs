using MediatR;
using Movies.Application.Models.Movies;
using Movies.Domain.Models;

namespace Movies.Application.Mediator.Commands
{
    public class CreateMovieCommand : IRequest<CreateMovieViewModel>
    {
        public MovieModel Movie { get; }

        public CreateMovieCommand(MovieModel newMovie)
        {
            this.Movie = newMovie;
        }
    }
}
