using MediatR;
using Movies.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Application.Mediator.Commands
{
    public class UpdateMovieCommand : IRequest<bool>
    {
        public MovieModel Movie { get; set; }

        public UpdateMovieCommand(MovieModel updatedMovie)
        {
            this.Movie = updatedMovie;
        }
    }
}
