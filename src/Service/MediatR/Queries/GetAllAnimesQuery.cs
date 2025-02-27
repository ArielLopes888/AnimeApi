using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Service.DTOs;

namespace Service.MediatR.Queries
{
    public class GetAllAnimesQuery : IRequest<IEnumerable<AnimeDto>>
    {
    }
}
