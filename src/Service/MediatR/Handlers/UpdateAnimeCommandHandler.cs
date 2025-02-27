using Infra.Repositories;
using MediatR;
using Service.MediatR.Commands;


namespace Service.MediatR.Handlers
{
    public class UpdateAnimeCommandHandler : IRequestHandler<UpdateAnimeCommand, bool>
    {
        private readonly IAnimeRepository _animeRepository;

        public UpdateAnimeCommandHandler(IAnimeRepository animeRepository)
        {
            _animeRepository = animeRepository;
        }

        public async Task<bool> Handle(UpdateAnimeCommand request, CancellationToken cancellationToken)
        {
            var existingAnime = await _animeRepository.GetAnimeByIdAsync(request.Id);
            if (existingAnime == null)
            {
                return false;
            }

            existingAnime.Name = request.AnimeDto.Name;
            existingAnime.Director = request.AnimeDto.Director;
            existingAnime.Summary = request.AnimeDto.Summary;

            return await _animeRepository.UpdateAnimeAsync(existingAnime);
        }
    }
}
