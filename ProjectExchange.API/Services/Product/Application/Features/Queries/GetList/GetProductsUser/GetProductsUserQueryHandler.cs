using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.GetList.GetProductsUser {
    public class GetProductsUserQueryHandler : IRequestHandler<GetProductsUserQuery, EntityResponse<Product>> {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductsUserQueryHandler (IProductRepository productRepository, IMapper mapper) {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<EntityResponse<Product>> Handle (GetProductsUserQuery request, CancellationToken cancellationToken) {
            var response = new EntityResponse<Product> () { ReponseName = nameof (GetProductsUserQuery), Content = new List<Product> () { } };
            var entities = new List<Product> ();
            foreach (var item in request.productIds) {
                entities.Add (await _productRepository.GetAsync (p => (p.Id == item)));
            }

            _mapper.Map<List<Product>> (entities);

            if (entities == null) {
                response.Status = ResponseType.Warning;
                response.Message = $"No {nameof(Product)}s were found.";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(Product)}s get successfully.";
                response.Content.AddRange (entities);
            }
            return response;
        }
    }
}