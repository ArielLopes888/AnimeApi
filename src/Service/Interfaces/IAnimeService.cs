using Domain.Entities;

namespace Service.Interfaces
{
    public interface IAnimeService
    {
        Task<IEnumerable<Anime>> GetAllAnimesAsync();
        Task<Anime> GetAnimeByIdAsync(int id);
        Task<Anime> CreateAnimeAsync(Anime anime);
        Task<Anime> UpdateAnimeAsync(Anime anime);
        Task<bool> DeleteAnimeAsync(int id);
    }
}
