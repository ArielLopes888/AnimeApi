using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infra.Context
{
    public class AnimeDbContext : DbContext
    {
        public AnimeDbContext(DbContextOptions<AnimeDbContext> options) : base(options) { }

        public DbSet<Anime> Animes { get; set; }
    }
}
