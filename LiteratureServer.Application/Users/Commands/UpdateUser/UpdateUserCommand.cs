using LiteratureServer.Application.Common.Exceptions;
using LiteratureServer.Application.Common.Interfaces;
using LiteratureServer.Application.Common.Managers;
using LiteratureServer.Application.Common.Models;
using LiteratureServer.Domain.Enums;
using LiteratureServer.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LiteratureServer.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<BaseResponseModel<long>>
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public IFormFile? ProfilePhoto { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTime Birthdate { get; set; }

        public class Handler : IRequestHandler<UpdateUserCommand, BaseResponseModel<long>>
        {
            private readonly UserManager<User> _userManager;
            private readonly IApplicationContext _context;
            private readonly FileManager _fileManager;

            public Handler(IApplicationContext context, FileManager fileManager, UserManager<User> userManager)
            {
                _context = context;
                _fileManager = fileManager;
                _userManager = userManager;
            }

            public async Task<BaseResponseModel<long>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    User? entity = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id);

                    if (entity == null)
                        throw new BadRequestException("Güncellenecek kullanıcı bulunamadı.");

                    entity.FirstName = request.FirstName;
                    entity.Surname = request.Surname;
                    entity.Email = request.Email;
                    entity.Gender = request.Gender;
                    entity.ProfilePhoto = _fileManager.Upload(request.ProfilePhoto,FileRoot.UserProfile);
                    entity.PhoneNumber = request.Phone;
                    entity.Birthdate = request.Birthdate;
                    
                    await _userManager.UpdateAsync(entity);

                    if (!string.IsNullOrEmpty(request.Password))
                    {
                        var removeResult = await _userManager.RemovePasswordAsync(entity);
                        if (removeResult.Succeeded)
                        {
                            await _userManager.AddPasswordAsync(entity, request.Password);
                        }
                        else
                        {
                            throw new BadRequestException(
                                $"(UUC-0) Kullanıcı güncellenirken şifre değiştirme sırasında hata meydana geldi.");
                        }
                    }
                    
                    return BaseResponseModel<long>.Success(entity.Id,$"Kullanıcı başarıyla oluşturuldu. Username: {request.Email}");
                }
                catch (Exception e)
                {
                    throw new BadRequestException(
                        $"({request.Email}) Kullanıcı oluşturulurken hata meydana geldi. Hata: {e.Message}");
                }
            }
        }
    }
}