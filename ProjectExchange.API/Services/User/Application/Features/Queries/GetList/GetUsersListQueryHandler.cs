using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.GetList {
    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, List<User>> {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUsersListQueryHandler (IUserRepository userRepository, IMapper mapper) {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<User>> Handle (GetUsersListQuery request, CancellationToken cancellationToken) {
            var userList = await _userRepository.GetAllAsync ();
            return _mapper.Map<List<User>> (userList);
        }
    }
}