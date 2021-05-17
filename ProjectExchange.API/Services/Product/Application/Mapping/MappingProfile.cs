using Application.Features.Commands.CreateCommand;
using Application.Features.Commands.UpdateCommand;
using Application.Features.Queries.GetList.GetProductsByName;
using Application.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping {
    public class MappingProfile : Profile {
        public MappingProfile () {
            CreateMap<Product, ProductVm> ().ReverseMap ();
            CreateMap<Product, CreateProductCommand> ().ReverseMap ();
            CreateMap<Product, UpdateProductCommand> ().ReverseMap ();
            CreateMap<Product, GetProductsByNameQuery> ().ReverseMap ();
        }
    }
}