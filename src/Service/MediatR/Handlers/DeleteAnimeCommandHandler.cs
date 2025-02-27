using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;  
using Service.MediatR.Commands;

namespace Service.MediatR.Handlers
{
    public class DeleteAnimeCommandHandler : IRequestHandler<DeleteAnimeCommand, bool>
    {
        private readonly IAnimeRepository _animeRepository;
        private readonly ILogger<DeleteAnimeCommandHandler> _logger;

        public DeleteAnimeCommandHandler(IAnimeRepository animeRepository, ILogger<DeleteAnimeCommandHandler> logger)
        {
            _animeRepository = animeRepository;
            _logger = logger;
        }

        public async Task<bool> Handle(DeleteAnimeCommand request, CancellationToken cancellationToken)
        {
            try
            {
  
                var anime = await _animeRepository.GetAnimeByIdAsync(request.Id);
                if (anime == null)
                {
                    _logger.LogWarning("Anime com ID {AnimeId} não encontrado.", request.Id);
                    return false;  
                }

                var result = await _animeRepository.DeleteAnimeAsync(anime);

                if (result)
                {
                    
                    _logger.LogInformation("Anime com ID {AnimeId} excluído com sucesso.", request.Id);
                }
                else
                {
                  
                    _logger.LogError("Falha ao excluir anime com ID {AnimeId}.", request.Id);
                }

                return result; 
            }
            catch (Exception ex)
            {
                
                _logger.LogError(ex, "Erro ao tentar excluir anime com ID {AnimeId}.", request.Id);
                return false;  
            }
        }
    }
}
