using System;
using AutoMapper;
using LifeBoatMediatR.Common.Mappings;
using LifeBoatMediatR.Domain.Entities;

namespace LifeBoatMediatR.Application.Users.Queries.GetUsersList
{
    public class UserLookupDto : IMapFrom<User>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserLookupDto>();
                //.ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                //.ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                //.ForMember(d => d.Name, opt => opt.MapFrom(s => s.Email))
                //.ForMember(d => d.Name, opt => opt.MapFrom(s => s.BirthDate));
        }
    }
}
