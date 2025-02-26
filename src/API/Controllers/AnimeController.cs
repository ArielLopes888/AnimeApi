using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Service.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimeController : ControllerBase
    {
        private readonly IAnimeService _animeService;

        public AnimeController(IAnimeService animeService)
        {
            _animeService = animeService;
        }

        // GET: api/anime
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Anime>>> GetAllAnimes()
        {
            var animes = await _animeService.GetAllAnimesAsync();
            return Ok(animes);
        }

        // GET: api/anime/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Anime>> GetAnimeById(int id)
        {
            var anime = await _animeService.GetAnimeByIdAsync(id);
            if (anime == null)
            {
                return NotFound();
            }
            return Ok(anime);
        }

        // POST: api/anime
        [HttpPost]
        public async Task<ActionResult<Anime>> CreateAnime(Anime anime)
        {
            var createdAnime = await _animeService.CreateAnimeAsync(anime);
            return CreatedAtAction(nameof(GetAnimeById), new { id = createdAnime.Id }, createdAnime);
        }

        // PUT: api/anime/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnime(int id, Anime anime)
        {
            if (id != anime.Id)
            {
                return BadRequest();
            }

            var updatedAnime = await _animeService.UpdateAnimeAsync(anime);
            if (updatedAnime == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/anime/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnime(int id)
        {
            var isDeleted = await _animeService.DeleteAnimeAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
