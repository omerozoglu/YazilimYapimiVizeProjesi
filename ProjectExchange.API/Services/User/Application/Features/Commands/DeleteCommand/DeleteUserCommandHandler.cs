using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.Commands.DeleteCommand {
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool> {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public DeleteUserCommandHandler (IUserRepository userRepository, IMapper mapper) {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle (DeleteUserCommand request, CancellationToken cancellationToken) {
            var userToDelete = await _userRepository.GetByIdAsync (request.Id);
            await _userRepository.DeleteAsync (userToDelete);
            if (userToDelete == null) {
                return false;
            }
            return true;
        }
    }
}