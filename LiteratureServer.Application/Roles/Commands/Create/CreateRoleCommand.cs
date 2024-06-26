using LiteratureServer.Application.Common.Exceptions;
using LiteratureServer.Application.Common.Models;
using LiteratureServer.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace LiteratureServer.Application.Roles.Commands.Create;

public class CreateRoleCommand : IRequest<BaseResponseModel<Unit>>
{
    public string Name { get; set; }
    
    public class Handler : IRequestHandler<CreateRoleCommand, BaseResponseModel<Unit>>
    {
        private readonly RoleManager<Role> _roleManager;

        public Handler(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<BaseResponseModel<Unit>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            Role? role = await _roleManager.FindByNameAsync(request.Name);

            if (role != null)
            {
                throw new BadRequestException("This role already added.");
            }

            await _roleManager.CreateAsync(new Role
            {
                Name = request.Name
            });

            return BaseResponseModel<Unit>.Success(Unit.Value, "Role successfully added.");
        }
    }
}