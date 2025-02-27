using MediatR;

namespace Service.MediatR.Commands
{
    public class DeleteAnimeCommand : IRequest<bool>
    {
        public int Id { get; }

        public DeleteAnimeCommand(int id)
        {
            Id = id;
        }
    }
}
