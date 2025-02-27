using MediatR;
using Service.DTOs;

namespace Service.MediatR.Queries
{
    public class GetAnimeByIdQuery : IRequest<AnimeDto>
    {
        public int Id { get; set; }

        public GetAnimeByIdQuery(int id)
        {
            Id = id;
        }
    }
}
