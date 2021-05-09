using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using MediatR;

namespace Application.Features.Queries.Get {
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserVm> {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserQueryHandler (IUserRepository userRepository, IMapper mapper) {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserVm> Handle (GetUserQuery request, CancellationToken cancellationToken) {
            var user = await _userRepository.GetByIdAsync (request.Id);
            return _mapper.Map<UserVm> (user);
        }
    }
}