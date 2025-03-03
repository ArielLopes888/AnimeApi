﻿using MediatR;
using Service.DTOs;

namespace Service.MediatR.Queries
{
    public class GetAnimesByFilterQuery : IRequest<IEnumerable<AnimeDto>>
    {
        public int? Id { get; }
        public string? Name { get; }
        public string? Director { get; }

        public GetAnimesByFilterQuery(int? id, string? name, string? director)
        {
            Id = id;
            Name = name;
            Director = director;
        }
    }
}
