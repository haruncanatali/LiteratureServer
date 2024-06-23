using LiteratureServer.Application.Common.Exceptions;
using LiteratureServer.Application.Common.Interfaces;
using LiteratureServer.Application.Common.Managers;
using LiteratureServer.Application.Common.Models;
using LiteratureServer.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace LiteratureServer.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<BaseResponseModel<Unit>>
    {
        public long Id { get; set; }

        public class DeleteCategoryCommandHandler : IRequestHandler<DeleteUserCommand, BaseResponseModel<Unit>>
        {
            private readonly IApplicationContext _context;
            private readonly UserManager<User> _userManager;
            private readonly FileManager _fileManager;

            public DeleteCategoryCommandHandler(IApplicationContext context, UserManager<User> userManager, FileManager fileManager)
            {
                _context = context;
                _userManager = userManager;
                _fileManager = fileManager;
            }

            public async Task<BaseResponseModel<Unit>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Users
                    .FindAsync(request.Id);

                if (entity == null)
                {
                    throw new BadRequestException($"Silinmek istenen kullanıcı bulunamadı. ID:{request.Id}");
                }
                
                _fileManager.Delete(entity.ProfilePhoto);
                await _userManager.DeleteAsync(entity);
                
                await _context.SaveChangesAsync(cancellationToken);
                return BaseResponseModel<Unit>.Success(Unit.Value, $"Kullanıcı başarıyla silindi. ID:{request.Id}");
            }
        }
    }
}
