using API.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Microsoft.Extensions.Logging;
using Service.DTOs;
using Service.MediatR.Commands;

namespace Tests.ServiceTests.APITests
{
    public class AnimeControllerTests
    {
        private readonly AnimeController _controller;
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<ILogger<AnimeController>> _loggerMock;

        public AnimeControllerTests()
        {
            // Mockando o IMediator
            _mediatorMock = new Mock<IMediator>();

            // Mockando o ILogger
            _loggerMock = new Mock<ILogger<AnimeController>>();

            // Passando ambos os mocks para o construtor do AnimeController
            _controller = new AnimeController(_loggerMock.Object, _mediatorMock.Object);
        }

        [Fact]
        public async Task CreateAnime_ReturnsCreatedAtAction_WhenAnimeIsCreated()
        {
            // Arrange
            var animeDto = new AnimeDto
            {
                Name = "Attack on Titan",
                Director = "Tetsurō Araki",
                Summary = "Humanity fights for survival against giant humanoid creatures."
            };

            var createdAnime = new AnimeDto
            {
                Id = 1,
                Name = "Attack on Titan",
                Director = "Tetsurō Araki",
                Summary = "Humanity fights for survival against giant humanoid creatures."
            };

            // Mockando o retorno do MediatR
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateAnimeCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(createdAnime);

            // Act
            var result = await _controller.CreateAnimeAsync(animeDto);

            // Assert
            var createdResult = Assert.IsType<ActionResult<AnimeDto>>(result);
            var createdAtActionResult = createdResult.Result as CreatedAtActionResult;

            Assert.NotNull(createdAtActionResult);
            Assert.Equal(201, createdAtActionResult.StatusCode);
            var returnedAnime = Assert.IsType<AnimeDto>(createdAtActionResult.Value);
            Assert.Equal(createdAnime.Name, returnedAnime.Name);
            Assert.Equal(createdAnime.Director, returnedAnime.Director);
            Assert.Equal(createdAnime.Summary, returnedAnime.Summary);
        }
    }
}
