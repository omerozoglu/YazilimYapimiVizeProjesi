using Application.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping {
    public class MappingProfile : Profile {
        public MappingProfile () {
            CreateMap<Product, ProductVm> ().ReverseMap ();
        }
    }
}