
namespace MyApp.Application.Features.CQRS.Handlers.UserHandlers
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, List<GetUserQueryResult>>
    {
        private readonly IRepository<User> _repository;

        public GetUserQueryHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetUserQueryResult>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetAllAsync();

            return users.Select(u => new GetUserQueryResult
            {
                Id = u.Id,
                UserName = u.UserName,
                Role = u.Role
            }).ToList();
        }
    }
}
