using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Service.DTOs;

namespace Service.MediatR.Commands
{
    public class CreateAnimeCommand : IRequest<AnimeDto>
    {
        public AnimeDto Anime { get; }

        public CreateAnimeCommand(AnimeDto anime)
        {
            Anime = anime;
        }
    }
}
