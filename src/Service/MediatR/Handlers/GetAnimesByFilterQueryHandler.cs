using Infra.Repositories;
using MediatR;
using Service.DTOs;
using Service.MediatR.Queries;

namespace Service.MediatR.Handlers
{
    public class GetAnimesByFilterQueryHandler : IRequestHandler<GetAnimesByFilterQuery, IEnumerable<AnimeDto>>
    {
        private readonly IAnimeRepository _animeRepository;

        public GetAnimesByFilterQueryHandler(IAnimeRepository animeRepository)
        {
            _animeRepository = animeRepository;
        }

        public async Task<IEnumerable<AnimeDto>> Handle(GetAnimesByFilterQuery request, CancellationToken cancellationToken)
        {
            var animes = await _animeRepository.GetAnimesByFilterAsync(request.Id, request.Name, request.Director);


            return animes.Select(a => new AnimeDto
            {
                Id = a.Id,
                Name = a.Name,
                Director = a.Director
            });
        }
    }
}
