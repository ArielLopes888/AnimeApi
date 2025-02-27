using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Service.Interfaces;
using Service.DTOs;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
                return NotFound("Anime não encontrado.");
            }
            return Ok(anime);
        }

        // GET: api/anime/search
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<AnimeDto>>> SearchAnimes(
            [FromQuery] int? id,
            [FromQuery] string? name,
            [FromQuery] string? director)
        {
            var animes = await _animeService.GetAnimesByFilterAsync(id, name, director);

            if (animes == null || !animes.Any())
                return NotFound("Nenhum anime encontrado com os critérios informados.");

            return Ok(animes);
        }

        // POST: api/anime
        [HttpPost]
        public async Task<ActionResult<Anime>> CreateAnimeAsync([FromBody]AnimeDto animeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdAnime = await _animeService.CreateAnimeAsync(animeDto);
            return CreatedAtAction(nameof(GetAnimeById), new { id = createdAnime.Id }, createdAnime);
        }

        // PUT: api/anime/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnime(int id, [FromBody] AnimeDto animeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedAnime = await _animeService.UpdateAnimeAsync(id, animeDto);
            if (!updatedAnime)
            {
                return NotFound("Anime não encontrado.");
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
                return NotFound("Anime não encontrado.");
            }

            return NoContent();
        }
    }
}
