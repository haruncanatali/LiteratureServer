using AutoMapper;
using LiteratureServer.Application.Common.Helpers;
using LiteratureServer.Application.Common.Mappings;
using LiteratureServer.Domain.Enums;
using LiteratureServer.Domain.Identity;

namespace LiteratureServer.Application.Users.Queries.GetUserDetail
{
    public class UserDetailDto : IMapFrom<User>
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }

        public string GenderText
        {
            get
            {
                return Gender.GetDescription();
            }
        }

        public string ProfilePhoto { get; set; }
        public DateTime Birthdate { get; set; }
        public string BirthdateText { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDetailDto>()
                /*.ForMember(dest => GenderText, opt => 
                    opt.MapFrom(c=>c.Gender.GetDescription()))*/
                .ForMember(dest => dest.BirthdateText, opt =>
                    opt.MapFrom(c=>c.Birthdate.ToString("dd/MM/yyyy")));
        }
    }
}