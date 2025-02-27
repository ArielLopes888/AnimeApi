using Domain.Entities;
using Infra.Repositories;
using Moq;
using Service.DTOs;
using Service.MediatR.Handlers;
using Service.MediatR.Queries;
using System;

namespace Tests.ServiceTests.MediatorTests.QueryTest
{
    public class GetAnimesByFilterQueryHandlerTests
    {
        private readonly Mock<IAnimeRepository> _animeRepositoryMock;
        private readonly GetAnimesByFilterQueryHandler _handler;


        public GetAnimesByFilterQueryHandlerTests()
        {
            _animeRepositoryMock = new Mock<IAnimeRepository>();
            _handler = new GetAnimesByFilterQueryHandler(_animeRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ReturnsFilteredAnimes()
        {
            // Arrange
            var animeList = new List<Anime>
        {
            new Anime { Id = 1, Name = "Naruto", Director = "Masashi Kishimoto", Summary = "Anime sobre ninjas." },
            new Anime { Id = 2, Name = "One Piece", Director = "Eiichiro Oda", Summary = "Anime sobre piratas." },
            new Anime { Id = 3, Name = "Attack on Titan", Director = "Tetsurō Araki", Summary = "Anime sobre titãs." }
        };

            _animeRepositoryMock
                .Setup(repo => repo.GetAnimesByFilterAsync(It.IsAny<int?>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync((int? id, string? name, string? director) =>
                {
                    return animeList
                        .Where(a =>
                            (!id.HasValue || a.Id == id.Value) &&
                            (string.IsNullOrEmpty(name) || a.Name.Contains(name)) &&
                            (string.IsNullOrEmpty(director) || a.Director.Contains(director)))
                        .ToList();
                });

            var query = new GetAnimesByFilterQuery(name: "One Piece", id: null, director:null);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            var resultList = result.ToList(); 

            Assert.NotNull(resultList);
            Assert.IsType<List<AnimeDto>>(resultList);
            Assert.Single(resultList); 
            Assert.Equal("One Piece", resultList[0].Name);
        }

        [Fact]
        public async Task Handle_ReturnsEmptyListWhenNoMatches()
        {
            // Arrange
            var animeList = new List<Anime>
        {
            new Anime { Id = 1, Name = "Naruto", Director = "Masashi Kishimoto", Summary = "Anime sobre ninjas." },
            new Anime { Id = 2, Name = "One Piece", Director = "Eiichiro Oda", Summary = "Anime sobre piratas." }
        };

            _animeRepositoryMock
                .Setup(repo => repo.GetAnimesByFilterAsync(It.IsAny<int?>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync((int? id, string? name, string? director) =>
                {
                    return animeList
                        .Where(a =>
                            (!id.HasValue || a.Id == id.Value) &&
                            (string.IsNullOrEmpty(name) || a.Name.Contains(name)) &&
                            (string.IsNullOrEmpty(director) || a.Director.Contains(director)))
                        .ToList();
                });

            var query = new GetAnimesByFilterQuery ( name: "Dragon Ball", id: null, director: null); 

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            var resultList = result.ToList(); 

            Assert.NotNull(resultList);
            Assert.IsType<List<AnimeDto>>(resultList);
            Assert.Empty(resultList); 
        }
    }
}
