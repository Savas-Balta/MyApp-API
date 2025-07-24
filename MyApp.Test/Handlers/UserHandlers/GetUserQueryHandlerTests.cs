using Moq;
using MyApp.Application.Features.CQRS.Handlers.UserHandlers;
using MyApp.Application.Features.CQRS.Queries.UserQueries;
using MyApp.Application.Interfaces;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyApp.Test.Handlers.UserHandlers
{
    public class GetUserQueryHandlerTests
    {
        private readonly Mock<IRepository<User>> _mockRepository;
        private readonly GetUserQueryHandler _handler;

        public GetUserQueryHandlerTests()
        {
            _mockRepository = new Mock<IRepository<User>>();
            _handler = new GetUserQueryHandler(_mockRepository.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnUserList()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Id = 1, UserName = "admin", Role = "Admin" },
                new User { Id = 2, UserName = "editor", Role = "Editor" }
            };

            _mockRepository.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(users);

            // Act
            var result = await _handler.Handle(new GetUserQuery(), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("admin", result[0].UserName);
            Assert.Equal("Editor", result[1].Role);
        }
    }
}
