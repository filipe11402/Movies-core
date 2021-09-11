using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Application.Mediator.Commands
{
    public class DeleteMovieCommand : IRequest<bool>
    {
        public string Id { get; }

        public DeleteMovieCommand(string id)
        {
            this.Id = id;
        }
    }
}
