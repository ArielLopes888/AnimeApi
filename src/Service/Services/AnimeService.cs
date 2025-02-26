using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infra.Context;
using Service.Interfaces;

namespace Service.Services
{
    public class AnimeService : IAnimeService
    {
        private readonly AnimeDbContext _context;

        public AnimeService(AnimeDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Anime>> GetAllAnimesAsync()
        {
            return await _context.Animes.ToListAsync();
        }

        public async Task<Anime> GetAnimeByIdAsync(int id)
        {
            return await _context.Animes.FindAsync(id);
        }

        public async Task<Anime> CreateAnimeAsync(Anime anime)
        {
            _context.Animes.Add(anime);
            await _context.SaveChangesAsync();
            return anime;
        }

        public async Task<Anime> UpdateAnimeAsync(Anime anime)
        {
            _context.Entry(anime).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return anime;
        }

        public async Task<bool> DeleteAnimeAsync(int id)
        {
            var anime = await _context.Animes.FindAsync(id);
            if (anime == null)
            {
                return false;
            }

            _context.Animes.Remove(anime);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
