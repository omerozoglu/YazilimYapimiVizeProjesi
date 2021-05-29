using Application.Features.MoneyApprovals.Commands.Create;
using Application.Features.MoneyApprovals.Commands.Update;
using Application.Features.ProductApprovals.Commands.Create;
using Application.Features.ProductApprovals.Commands.Update;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping {
    public class MappingProfile : Profile {
        public MappingProfile () {
            CreateMap<MoneyApproval, CreateMoneyApprovalCommand> ().ReverseMap ();
            CreateMap<ProductApproval, CreateProductApprovalCommand> ().ReverseMap ();
            CreateMap<MoneyApproval, UpdateMoneyApprovalCommand> ().ReverseMap ();
            CreateMap<ProductApproval, UpdateProductApprovalCommand> ().ReverseMap ();
        }
    }
}