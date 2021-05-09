using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Command.UpdateCommand {
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool> {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler (IUserRepository userRepository, IMapper mapper) {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle (UpdateUserCommand request, CancellationToken cancellationToken) {
            var userToUpdate = await _userRepository.GetByIdAsync (request.Id);
            if (userToUpdate == null) {
                return false;
            }
            _mapper.Map (request, userToUpdate, typeof (UpdateUserCommand), typeof (User));
            await _userRepository.UpdateAsync (userToUpdate);
            return true;
        }
    }
}