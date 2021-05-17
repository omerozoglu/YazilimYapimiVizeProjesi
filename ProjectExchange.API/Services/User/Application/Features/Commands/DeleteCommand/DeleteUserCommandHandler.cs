using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.DeleteCommand {
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, EntityResponse<User>> {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public DeleteUserCommandHandler (IUserRepository userRepository, IMapper mapper) {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<EntityResponse<User>> Handle (DeleteUserCommand request, CancellationToken cancellationToken) {
            var response = new EntityResponse<User> () { ReponseName = nameof (DeleteUserCommand), Content = new List<User> () { } };
            var userToDelete = await _userRepository.GetByIdAsync (request.Id);
            if (userToDelete == null) {
                response.Status = ResponseType.Error;
                response.Message = "User not found.";
                response.Content = null;
            } else {
                await _userRepository.DeleteAsync (userToDelete);
                response.Status = ResponseType.Success;
                response.Message = "User deleted successfully.";
                response.Content.Add (userToDelete);
            }
            return response;
        }
    }
}