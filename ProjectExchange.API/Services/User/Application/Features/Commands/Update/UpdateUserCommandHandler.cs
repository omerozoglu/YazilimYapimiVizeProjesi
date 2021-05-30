using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.Update {
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, EntityResponse<User>> {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler (IUserRepository userRepository, IMapper mapper) {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<EntityResponse<User>> Handle (UpdateUserCommand request, CancellationToken cancellationToken) {
            var response = new EntityResponse<User> () { ReponseName = nameof (UpdateUserCommand), Content = new List<User> () { } };
            var entity = await _userRepository.GetOneAsync (p => p.Id == request.Id);
            if (entity == null) {
                response.Status = ResponseType.Warning;
                response.Message = $"{nameof(User)} not found.";
                response.Content = null;
            } else {
                _mapper.Map (request, entity, typeof (UpdateUserCommand), typeof (User));
                await _userRepository.UpdateAsync (entity);
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(User)} updated successfully.";
                response.Content.Add (entity);
            }
            return response;
        }
    }
}