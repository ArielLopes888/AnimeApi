using Domain.Entities;
using Service.DTOs;

namespace Service.Interfaces
{
    public interface IAnimeService
    {
        Task<IEnumerable<AnimeDto>> GetAllAnimesAsync();
        Task<AnimeDto> GetAnimeByIdAsync(int id);
        Task<IEnumerable<AnimeDto>> GetAnimesByFilterAsync(int? id, string? name, string? director);
        Task<AnimeDto> CreateAnimeAsync(AnimeDto animeDto);
        Task<bool> UpdateAnimeAsync(int id, AnimeDto animeDto);
        Task<bool> DeleteAnimeAsync(int id);
    }
}
