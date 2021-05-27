using Application.Features.Commands.Create;
using Application.Features.Commands.Update;
using Application.Features.Queries.GetList;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping {
    public class MappingProfile : Profile {
        public MappingProfile () {
            CreateMap<CommonEntity<ProductApproval>, CreateCommonEntityCommand<ProductApproval>> ().ReverseMap ();
            CreateMap<CommonEntity<MoneyApproval>, CreateCommonEntityCommand<MoneyApproval>> ().ReverseMap ();
            CreateMap<CommonEntity<ProductApproval>, CreateCommonEntityCommand<ProductApproval>> ().ReverseMap ();
            CreateMap<CommonEntity<MoneyApproval>, UpdateCommonEntityCommand<MoneyApproval>> ().ReverseMap ();
            CreateMap<CommonEntity<ProductApproval>, UpdateCommonEntityCommand<ProductApproval>> ().ReverseMap ();
        }
    }
}