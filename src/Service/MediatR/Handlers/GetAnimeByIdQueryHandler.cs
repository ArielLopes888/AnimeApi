using MediatR;
using Service.DTOs;
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
     
            var anime = await _animeRepository.GetAnimeByIdAsync(request.Id);

            if (anime == null)
                return null;

            return new AnimeDto
            {
                Id = anime.Id,
                Name = anime.Name,
                Director = anime.Director
            };
        }
    }
}
