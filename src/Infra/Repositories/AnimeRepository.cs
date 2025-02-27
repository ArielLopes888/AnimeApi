using Domain.Entities;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class AnimeRepository : IAnimeRepository
    {
        private readonly AnimeDbContext _context;
        public AnimeRepository(AnimeDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Anime>> GetAllAnimesAsync()
        {
            return await _context.Animes.ToListAsync();
        }

        public async Task<Anime?> GetAnimeByIdAsync(int id)
        {
            return await _context.Animes.FindAsync(id);
        }

        public async Task<IEnumerable<Anime>> GetAnimesByFilterAsync(int? id, string? name, string? director)
        {
            var query = _context.Animes.AsQueryable();

            if (id.HasValue)
                query = query.Where(a => a.Id == id.Value);

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(a => a.Name.Contains(name));

            if (!string.IsNullOrWhiteSpace(director))
                query = query.Where(a => a.Director.Contains(director));

            return await query.ToListAsync();
        }

        public async Task<Anime> CreateAnimeAsync(Anime anime)
        {
            await _context.Animes.AddAsync(anime);
            await _context.SaveChangesAsync();
            return anime; 
        }

        public async Task<bool> UpdateAnimeAsync(Anime anime)
        {
            _context.Animes.Update(anime);
            return await _context.SaveChangesAsync() >0;
        }


        public async Task<bool> DeleteAnimeAsync(Anime anime)
        {
            _context.Animes.Remove(anime); 
            var result = await _context.SaveChangesAsync();  
            return result > 0; 
        }

    }
}
