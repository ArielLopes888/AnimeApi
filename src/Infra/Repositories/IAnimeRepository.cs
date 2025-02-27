using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public interface IAnimeRepository
    {
        Task<IEnumerable<Anime>> GetAllAnimesAsync();
        Task<Anime?> GetAnimeByIdAsync(int id);
        Task<IEnumerable<Anime>> GetAnimesByFilterAsync(int? id, string? name, string? director);
        Task CreateAnimeAsync(Anime anime);
        Task UpdateAnimeAsync(Anime anime);
        Task<bool> DeleteAnimeAsync(int id);
    }
}
