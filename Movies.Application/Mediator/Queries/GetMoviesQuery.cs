using MediatR;
using Movies.Application.Models.Movies;
using System.Collections.Generic;

namespace Movies.Application.Mediator.Queries
{
    public class GetMoviesQuery : IRequest<IEnumerable<MovieViewModel>>
    {
    }
}
