using MediatR;
using Service.DTOs;
using Service.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Infra.Repositories;
using Service.MediatR.Queries;

namespace Application.Handlers
{
    public class GetAnimeByIdQueryHandler : IRequestHandler<GetAnimeByIdQuery, AnimeDto>
    {
        private readonly IAnimeRepository _animeRepository;

        public GetAnimeByIdQueryHandler(IAnimeRepository animeRepository)
        {
            _animeRepository = animeRepository;
        }

        public async Task<AnimeDto> Handle(GetAnimeByIdQuery request, CancellationToken cancellationToken)
        {
            // Buscar o anime pelo ID
            var anime = await _animeRepository.GetAnimeByIdAsync(request.Id);

            if (anime == null)
                return null;

            // Converter a entidade Anime para o DTO
            return new AnimeDto
            {
                Id = anime.Id,
                Name = anime.Name,
                Director = anime.Director
            };
        }
    }
}
