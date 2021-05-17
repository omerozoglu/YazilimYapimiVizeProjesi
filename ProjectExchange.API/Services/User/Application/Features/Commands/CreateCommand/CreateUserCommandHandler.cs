using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.CreateCommand {
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, EntityResponse<User>> {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler (IUserRepository userRepository, IMapper mapper) {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<EntityResponse<User>> Handle (CreateUserCommand request, CancellationToken cancellationToken) {
            var response = new EntityResponse<User> () { ReponseName = nameof (CreateUserCommand), Content = new List<User> () { } };
            var userEntity = _mapper.Map<User> (request);
            var newUser = await _userRepository.AddAsync (userEntity);
            if (newUser == null) {
                response.Status = ResponseType.Error;
                response.Message = "User could not be created.";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = "User created successfully.";
                response.Content.Add (newUser);
            }
            return response;
        }
    }
}