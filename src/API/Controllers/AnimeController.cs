using Microsoft.AspNetCore.Mvc;
using Service.DTOs;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Service.MediatR.Queries;
using Service.MediatR.Commands;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimeController : ControllerBase
    {
        private readonly ILogger<AnimeController> _logger;
        private readonly IMediator _mediator;

        public AnimeController(ILogger<AnimeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        // GET: api/anime
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimeDto>>> GetAllAnimes()
        {
            try
            {
                var animes = await _mediator.Send(new GetAllAnimesQuery());
                return Ok(animes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter todos os animes.");
                return StatusCode(500, "Erro interno no servidor.");
            }
        }

        // GET: api/anime/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<AnimeDto>> GetAnimeById(int id)
        {
            try
            {
                var anime = await _mediator.Send(new GetAnimeByIdQuery(id));
                if (anime == null)
                {
                    return NotFound("Anime não encontrado.");
                }
                return Ok(anime);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter anime por ID.");
                return StatusCode(500, "Erro interno no servidor.");
            }
        }

        // GET: api/anime/search
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<AnimeDto>>> SearchAnimes(
            [FromQuery] int? id,
            [FromQuery] string? name,
            [FromQuery] string? director)
        {
            try
            {
                var query = new GetAnimesByFilterQuery(id, name, director);
                var animes = await _mediator.Send(query);

                if (animes == null || !animes.Any())
                    return NotFound("Nenhum anime encontrado com os critérios informados.");

                return Ok(animes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar animes.");
                return StatusCode(500, "Erro interno no servidor.");
            }
        }
        // POST: api/anime
        [HttpPost]
        public async Task<ActionResult<AnimeDto>> CreateAnimeAsync([FromBody] AnimeDto animeDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var createdAnime = await _mediator.Send(new CreateAnimeCommand(animeDto));
                return CreatedAtAction(nameof(GetAnimeById), new { id = createdAnime.Id }, createdAnime);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar anime.");
                return StatusCode(500, "Erro interno no servidor.");
            }
        }

        // PUT: api/anime/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnime(int id, [FromBody] AnimeDto animeDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var updatedAnime = await _mediator.Send(new UpdateAnimeCommand(id, animeDto));
                if (!updatedAnime)
                {
                    return NotFound("Anime não encontrado.");
                }

                return StatusCode(200, "Alterado com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar anime.");
                return StatusCode(500, "Erro interno no servidor.");
            }
        }

        // DELETE: api/anime/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnime(int id)
        {
            try
            {
      
                var anime = await _mediator.Send(new GetAnimeByIdQuery(id));

                if (anime == null)
                {
                   
                    return NotFound("Anime não encontrado.");
                }

         
                var isDeleted = await _mediator.Send(new DeleteAnimeCommand(id));

           
                if (isDeleted)
                {
              
                    return StatusCode(200, "Apagado com sucesso!");
                }

                
                return StatusCode(500, "Erro ao tentar apagar o anime.");
            }
            catch (Exception ex)
            {
                
                _logger.LogError(ex, "Erro ao excluir anime.");
                return StatusCode(500, "Erro interno no servidor.");
            }

        }
    }
}
