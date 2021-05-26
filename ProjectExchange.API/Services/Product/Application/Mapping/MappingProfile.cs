using Application.Features.Commands.Create;
using Application.Features.Commands.Update;
using Application.Features.Queries.GetList.GetProductsByName;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping {
    public class MappingProfile : Profile {
        public MappingProfile () {
            CreateMap<Product, CreateProductCommand> ().ReverseMap ();
            CreateMap<Product, UpdateProductCommand> ().ReverseMap ();
            CreateMap<Product, GetProductsByNameQuery> ().ReverseMap ();
        }
    }
}