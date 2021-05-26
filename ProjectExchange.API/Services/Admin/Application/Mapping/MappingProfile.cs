using Application.Features.Commands.Create;
using Application.Features.Commands.Update;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping {
    public class MappingProfile : Profile {
        public MappingProfile () {
            CreateMap<CommonEntity, CreateCommonEntityCommand> ().ReverseMap ();
            CreateMap<CommonEntity, UpdateCommonEntityCommand> ().ReverseMap ();
        }
    }
}