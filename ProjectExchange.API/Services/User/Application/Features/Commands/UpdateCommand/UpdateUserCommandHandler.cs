using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.UpdateCommand {
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, EntityResponse<User>> {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler (IUserRepository userRepository, IMapper mapper) {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<EntityResponse<User>> Handle (UpdateUserCommand request, CancellationToken cancellationToken) {
            var userToUpdate = await _userRepository.GetByIdAsync (request.Id);
            var response = new EntityResponse<User> () { ReponseName = nameof (UpdateUserCommand), Content = new List<User> () { } };
            if (userToUpdate == null) {
                response.Status = ResponseType.Error;
                response.Message = "User not found.";
                response.Content = null;
            } else {
                _mapper.Map (request, userToUpdate, typeof (UpdateUserCommand), typeof (User));
                await _userRepository.UpdateAsync (userToUpdate);
                response.Status = ResponseType.Success;
                response.Message = "User updated successfully.";
                response.Content.Add (userToUpdate);
            }
            return response;
        }
    }
}