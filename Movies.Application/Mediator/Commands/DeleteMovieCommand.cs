using MediatR;

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
