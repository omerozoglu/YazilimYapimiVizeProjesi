using Application.Features.Commands.CreateCommand;
using Application.Features.Commands.UpdateCommand;
using Application.Features.Commands.UpdateCommand.UpdateOneProperty;
using Application.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping {
    public class MappingProfile : Profile {
        public MappingProfile () {
            CreateMap<User, UserVm> ().ReverseMap ();
            CreateMap<User, CreateUserCommand> ().ReverseMap ();
            CreateMap<User, UpdateUserCommand> ().ReverseMap ();
            CreateMap<UpdateOnePropModel, UpdateOnePropertyCommand> ().ReverseMap ();
        }
    }
}