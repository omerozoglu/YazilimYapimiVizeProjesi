using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.Delete {
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, EntityResponse<User>> {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public DeleteUserCommandHandler (IUserRepository userRepository, IMapper mapper) {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<EntityResponse<User>> Handle (DeleteUserCommand request, CancellationToken cancellationToken) {
            var response = new EntityResponse<User> () { ReponseName = nameof (DeleteUserCommand), Content = new List<User> () { } };
            var entity = await _userRepository.GetOneAsync (p => p.Id == request.Id);
            if (entity == null) {
                response.Status = ResponseType.Warning;
                response.Message = $"{nameof(User)} not found.";
                response.Content = null;
            } else {
                await _userRepository.DeleteAsync (entity);
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(User)} deleted successfully.";
                response.Content.Add (entity);
            }
            return response;
        }
    }
}