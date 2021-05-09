using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using MediatR;

namespace Application.Features.Queries.GetList {
    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, List<UserVm>> {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUsersListQueryHandler (IUserRepository userRepository, IMapper mapper) {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserVm>> Handle (GetUsersListQuery request, CancellationToken cancellationToken) {
            var userList = await _userRepository.GetAllAsync ();
            return _mapper.Map<List<UserVm>> (userList);
        }
    }
}