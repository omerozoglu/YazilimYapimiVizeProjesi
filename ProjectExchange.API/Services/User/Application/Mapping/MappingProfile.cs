using Application.Features.Commands.Create;
using Application.Features.Commands.Update;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping {
    public class MappingProfile : Profile {
        public MappingProfile () {
            CreateMap<User, CreateUserCommand> ().ReverseMap ();
            CreateMap<User, UpdateUserCommand> ().ReverseMap ();
        }
    }
}