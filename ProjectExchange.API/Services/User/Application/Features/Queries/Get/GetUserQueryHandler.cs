using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.Get {
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, EntityResponse<User>> {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserQueryHandler (IUserRepository userRepository, IMapper mapper) {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<EntityResponse<User>> Handle (GetUserQuery request, CancellationToken cancellationToken) {
            var response = new EntityResponse<User> () { ReponseName = nameof (GetUserQuery), Content = new List<User> () { } };
            var user = await _userRepository.GetOneAsync (p => p.Id == request.Id);
            user = _mapper.Map<User> (user);
            if (user == null) {
                response.Status = ResponseType.Error;
                response.Message = $"{nameof(User)} not found.";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(User)} get successfully.";
                response.Content.Add (user);
            }
            return response;
        }
    }
}