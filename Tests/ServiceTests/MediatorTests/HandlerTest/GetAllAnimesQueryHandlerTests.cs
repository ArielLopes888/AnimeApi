using Moq;
using MediatR;
using Xunit;
using Service.DTOs;
using Service.MediatR.Queries;
using Infra.Repositories;
using Domain.Entities;
using Service.MediatR.Handlers;



namespace Tests.ServiceTests.MediatorTests.HandlerTest
{
    public class GetAllAnimesQueryHandlerTests
    {
        private readonly Mock<IAnimeRepository> _animeRepositoryMock;
        private readonly IRequestHandler<GetAllAnimesQuery, IEnumerable<AnimeDto>> _handler;

        public GetAllAnimesQueryHandlerTests()
        {
            _animeRepositoryMock = new Mock<IAnimeRepository>();
            _handler = new GetAllAnimesQueryHandler(_animeRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ReturnsListOfAnimeDto()
        {
            // Arrange
            var animeList = new List<Anime>
    {
        new Anime { Id = 1, Name = "Naruto", Director = "Masashi Kishimoto", Summary = "Anime sobre ninjas." },
        new Anime { Id = 2, Name = "One Piece", Director = "Eiichiro Oda", Summary = "Anime sobre piratas." }
    };

            _animeRepositoryMock
                .Setup(repo => repo.GetAllAnimesAsync())
                .ReturnsAsync(animeList);

            var query = new GetAllAnimesQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            var resultList = result.ToList(); 

            Assert.NotNull(resultList);
            Assert.IsType<List<AnimeDto>>(resultList);
            Assert.Equal(2, resultList.Count); 
            Assert.Equal("Naruto", resultList[0].Name); 
        }
    }
}
