using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.Get {
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, User> {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserQueryHandler (IUserRepository userRepository, IMapper mapper) {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<User> Handle (GetUserQuery request, CancellationToken cancellationToken) {
            var user = await _userRepository.GetByIdAsync (request.Id);
            return _mapper.Map<User> (user);
        }
    }
}