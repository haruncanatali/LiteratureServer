﻿using LiteratureServer.Application.Common.Exceptions;
using LiteratureServer.Application.Common.Interfaces;
using LiteratureServer.Application.Common.Managers;
using LiteratureServer.Application.Common.Models;
using LiteratureServer.Domain.Enums;
using LiteratureServer.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;


namespace LiteratureServer.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<BaseResponseModel<long>>
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string DeviceToken { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IFormFile? Photo { get; set; }
        public string? RoleName { get; set; }

        public class Handler : IRequestHandler<CreateUserCommand, BaseResponseModel<long>>
        {
            private readonly UserManager<User> _userManager;
            private readonly RoleManager<Role> _roleManager;
            private readonly IApplicationContext _context;
            private readonly FileManager _fileManager;

            public Handler(UserManager<User> userManager, RoleManager<Role> roleManager, FileManager fileManager,
                IApplicationContext context)
            {
                _userManager = userManager;
                _roleManager = roleManager;
                _fileManager = fileManager;
                _context = context;
            }

            public async Task<BaseResponseModel<long>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    bool dublicateControl = _context.Users.Any(x => x.Email == request.Email);
                    if (dublicateControl)
                    {
                        throw new BadRequestException("Eklenmek istenen kullanıcı mükerrer kontrolden geçemedi. Aynı kullanıcı adı veya E-Posta'ya sahip kullanıcı sistemde mevcut görünüyor.");
                    }
                    
                    User entity = new()
                    {
                        FirstName = request.FirstName,
                        Surname = request.Surname,
                        UserName = request.Email,
                        Email = request.Email,
                        Gender = request.Gender,
                        ProfilePhoto = _fileManager.Upload(request.Photo, FileRoot.UserProfile),
                        Birthdate = request.Birthdate,
                        RefreshToken = String.Empty,
                        RefreshTokenExpiredTime = DateTime.Now,
                        PhoneNumber = request.Phone,
                        DeviceToken = request.DeviceToken
                    };

                    var response = await _userManager.CreateAsync(entity, request.Password);

                    if (response.Succeeded)
                    {
                        Role? normalRole = await _roleManager.FindByNameAsync("Normal");

                        if (normalRole == null)
                        {
                            await _roleManager.CreateAsync(new Role
                            {
                                Name = "Normal"
                            });
                        }

                        if (request.RoleName != null)
                        {
                            Role? role = await _roleManager.FindByNameAsync(request.RoleName);
                    
                            if (role != null)
                            {
                                await _userManager.AddToRoleAsync(entity, request.RoleName);
                            }
                            else
                            {
                                await _userManager.AddToRoleAsync(entity, "Normal");
                            }
                        }
                        else
                        {
                            await _userManager.AddToRoleAsync(entity, "Normal");
                        }
                    }
                    else
                    {
                        throw new BadRequestException($"Kullanıcı eklenirken hata meydana geldi.");
                    }
                    
                    
                    return BaseResponseModel<long>.Success(entity.Id, $"Kullanıcı başarıyla eklendi. Username:{request.Email}");
                }
                catch (Exception e)
                {
                    throw new BadRequestException($"Kullanıcı ({request.Email}) eklenirken hata meydana geldi. Hata: {e.Message}");
                }
            }
        }
    }
}