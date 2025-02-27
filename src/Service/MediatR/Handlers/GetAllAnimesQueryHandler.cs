using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.Repositories;
using MediatR;
using Service.DTOs;
using Service.Interfaces;
using Service.MediatR.Queries;

namespace Service.MediatR.Handlers
{
    public class GetAllAnimesQueryHandler : IRequestHandler<GetAllAnimesQuery, IEnumerable<AnimeDto>>
    {
        private readonly IAnimeRepository _animeRepository;

        public GetAllAnimesQueryHandler(IAnimeRepository animeRepository)
        {
            _animeRepository = animeRepository;
        }

        public async Task<IEnumerable<AnimeDto>> Handle(GetAllAnimesQuery request, CancellationToken cancellationToken)
        {
     
            var animes = await _animeRepository.GetAllAnimesAsync();


            return animes.Select(a => new AnimeDto
            {
                Id = a.Id,
                Name = a.Name,
                Director = a.Director
            });
        }
    }
}
