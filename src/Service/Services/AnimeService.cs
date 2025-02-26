using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infra.Context;
using Service.Interfaces;
using Infra.Repositories;
using Service.DTOs;

namespace Service.Services
{
    public class AnimeService : IAnimeService
    {
        private readonly IAnimeRepository _animeRepository;
        public AnimeService(IAnimeRepository animeRepository)
        {
            _animeRepository = animeRepository;
        }

        public async Task<IEnumerable<AnimeDto>> GetAllAnimesAsync()
        {
            var animes = await _animeRepository.GetAllAnimesAsync();
            return animes.Select(a => new AnimeDto
            {
                Id = a.Id,
                Name = a.Name,
                Director = a.Director,
                Summary = a.Summary
            });
        }

        public async Task<AnimeDto> GetAnimeByIdAsync(int id)
        {
            var anime = await _animeRepository.GetAnimeByIdAsync(id);
            if (anime == null) return null;

            return new AnimeDto
            {
                Name = anime.Name,
                Director = anime.Director,
                Summary = anime.Summary
            };
        }

        public async Task<IEnumerable<AnimeDto>> GetAnimesByFilterAsync(int? id, string? name, string? director)
        {
            var animes = await _animeRepository.GetAnimesByFilterAsync(id, name, director);
            return animes.Select(a => new AnimeDto { Id = a.Id, Name = a.Name, Director = a.Director, Summary = a.Summary });
        }

        public async Task<AnimeDto> CreateAnimeAsync(AnimeDto animeDto)
        {
            var anime = new Anime
            {
                Name = animeDto.Name,
                Director = animeDto.Director,
                Summary = animeDto.Summary
            };

            await _animeRepository.CreateAnimeAsync(anime);
            return new AnimeDto
            {
                Id = anime.Id,
                Name = anime.Name,
                Director = anime.Director,
                Summary = anime.Summary
            };
        }

        public async Task<bool> UpdateAnimeAsync(int id,AnimeDto animeDto)
        {
            var anime = await _animeRepository.GetAnimeByIdAsync(id);
            if (anime == null) return false;

            anime.Name = animeDto.Name;
            anime.Director = animeDto.Director;
            anime.Summary = animeDto.Summary;

            await _animeRepository.UpdateAnimeAsync(anime);
            return true;
        }

        public async Task<bool> DeleteAnimeAsync(int id)
        {
            return await _animeRepository.DeleteAnimeAsync(id);
        }
    }
}
