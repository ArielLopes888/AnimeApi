using MediatR;
using Service.DTOs;

namespace Service.MediatR.Queries
{
    public class GetAllAnimesQuery : IRequest<IEnumerable<AnimeDto>>
    {
    }
}
