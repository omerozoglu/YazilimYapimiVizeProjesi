using Application.Features.Commands.Create;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping {
    public class MappingProfile : Profile {
        public MappingProfile () {
            CreateMap<Report, CreateReportCommand> ().ReverseMap ();
        }
    }
}