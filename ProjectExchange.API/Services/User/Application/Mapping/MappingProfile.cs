using Application.Features.Command.CreateCommand;
using Application.Features.Command.UpdateCommand;
using Application.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping {
    public class MappingProfile : Profile {
        public MappingProfile () {
            CreateMap<User, UserVm> ().ReverseMap ();
            CreateMap<User, CreateUserCommand> ().ReverseMap ();
            CreateMap<User, UpdateUserCommand> ().ReverseMap ();
        }
    }
}