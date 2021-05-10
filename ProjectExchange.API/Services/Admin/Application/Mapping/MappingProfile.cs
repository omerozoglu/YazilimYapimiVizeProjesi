using Application.Features.Commands.CreateCommand;
using Application.Features.Commands.UpdateCommand;
using Application.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping {
    public class MappingProfile : Profile {
        public MappingProfile () {
            CreateMap<CommonEntity, CommonEntityVm> ().ReverseMap ();
            CreateMap<CommonEntity, CreateCommonEntityCommand> ().ReverseMap ();
            CreateMap<CommonEntity, UpdateCommonEntityCommand> ().ReverseMap ();
        }
    }
}