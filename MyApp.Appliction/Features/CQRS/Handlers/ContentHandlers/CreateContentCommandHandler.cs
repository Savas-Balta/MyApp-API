using MediatR;
using Microsoft.AspNetCore.Http;
using MyApp.Application.Features.CQRS.Commands.Content;
using MyApp.Application.Interfaces;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.CQRS.Handlers.ContentHandlers
{
    public class CreateContentCommandHandler : IRequestHandler<CreateContentCommand, Unit>
    {
        private readonly IRepository<Content> _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateContentCommandHandler(IRepository<Content> repository, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Unit> Handle(CreateContentCommand request, CancellationToken cancellationToken)
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!int.TryParse(userIdClaim, out var userIdFromToken) || userIdFromToken <= 0)
            {
                throw new UnauthorizedAccessException("Geçersiz kullanıcı kimliği.");
            }


            await _repository.CreateAsync(new Content
            {
                Title = request.Title,
                Body = request.Body,
                UserId = userIdFromToken,
                CategoryId = request.CategoryId,
                IsDeleted = false, 
                CreatedAt = DateTime.UtcNow 
            });

            return Unit.Value;
        }
    }
}
