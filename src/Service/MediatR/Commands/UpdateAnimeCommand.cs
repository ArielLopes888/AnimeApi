using MediatR;
using Service.DTOs;


namespace Service.MediatR.Commands
{
    public class UpdateAnimeCommand : IRequest<bool>
    {
        public int Id { get; }
        public AnimeDto AnimeDto { get; }

        public UpdateAnimeCommand(int id, AnimeDto animeDto)
        {
            Id = id;
            AnimeDto = animeDto;
        }
    }
}
