
namespace MyApp.Test.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandlerTests
    {
        private readonly Mock<IRepository<Category>> _mockRepository;
        private readonly GetCategoryQueryHandler _handler;

        public GetCategoryQueryHandlerTests()
        {
            _mockRepository = new Mock<IRepository<Category>>();
            _handler = new GetCategoryQueryHandler(_mockRepository.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnCategoryList()
        {
            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "Test 1" },
                new Category { Id = 2, Name = "Test 2" }
            };

            _mockRepository.Setup(repo => repo.GetAllAsync())
                           .ReturnsAsync(categories);

            var result = await _handler.Handle(new GetCategoryQuery(), CancellationToken.None);

            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            result.First().Name.Should().Be("Test 1");
            result.Last().Id.Should().Be(2);
        }
    }
}
