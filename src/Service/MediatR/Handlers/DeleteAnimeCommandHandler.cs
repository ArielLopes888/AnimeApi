using Infra.Repositories;
using MediatR;
using Service.Interfaces;
using Service.MediatR.Commands;

namespace Service.MediatR.Handlers
{
    public class DeleteAnimeCommandHandler : IRequestHandler<DeleteAnimeCommand, bool>
    {
        private readonly IAnimeRepository _animeRepository;

        public DeleteAnimeCommandHandler(IAnimeRepository animeRepository)
        {
            _animeRepository = animeRepository;
        }

        public async Task<bool> Handle(DeleteAnimeCommand request, CancellationToken cancellationToken)
        {
            var anime = await _animeRepository.GetAnimeByIdAsync(request.Id);
            if (anime == null)
            {
                return false;
            }

            return await _animeRepository.DeleteAnimeAsync(anime);
        }
    }
}
