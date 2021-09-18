using MediatR;
using Movies.Application.Models.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Application.Mediator.Queries
{
    public class GetMovieQuery : IRequest<MovieViewModel>
    {
        public string Id { get; }

        public GetMovieQuery(string id)
        {
            this.Id = id;
        }
    }
}
