using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Command.CreateCommand {
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool> {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler (IUserRepository userRepository, IMapper mapper) {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle (CreateUserCommand request, CancellationToken cancellationToken) {
            var userEntity = _mapper.Map<User> (request);
            var newUser = await _userRepository.AddAsync (userEntity);
            if (newUser == null) {
                return false;
            }
            return true;
        }
    }
}