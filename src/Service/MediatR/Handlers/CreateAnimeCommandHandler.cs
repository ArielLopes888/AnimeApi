using Infra.Repositories;
using MediatR;
using Service.DTOs;
using Service.MediatR.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Service.MediatR.Handlers
{
    public class CreateAnimeCommandHandler : IRequestHandler<CreateAnimeCommand, AnimeDto>
    {
        private readonly IAnimeRepository _animeRepository;

        public CreateAnimeCommandHandler(IAnimeRepository animeRepository)
        {
            _animeRepository = animeRepository;
        }

        public async Task<AnimeDto> Handle(CreateAnimeCommand request, CancellationToken cancellationToken)
        {
            var animeEntity = new Anime
            {
                Name = request.Anime.Name,
                Director = request.Anime.Director,
                Summary = request.Anime.Summary
            };

            var createdAnime = await _animeRepository.CreateAnimeAsync(animeEntity);

            return new AnimeDto
            {
                Id = createdAnime.Id,
                Name = createdAnime.Name,
                Director = createdAnime.Director,
                Summary = createdAnime.Summary
            };
        }
    }
}
