using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.Create {
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, EntityResponse<User>> {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler (IUserRepository userRepository, IMapper mapper) {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<EntityResponse<User>> Handle (CreateUserCommand request, CancellationToken cancellationToken) {
            var response = new EntityResponse<User> () { ReponseName = nameof (CreateUserCommand), Content = new List<User> () { } };
            var entity = _mapper.Map<User> (request);
            var newentity = await _userRepository.AddAsync (entity);
            if (newentity == null) {
                response.Status = ResponseType.Warning;
                response.Message = $"{nameof(User)} could not be created.";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(User)} created successfully.";
                response.Content.Add (newentity);
            }
            return response;
        }
    }
}