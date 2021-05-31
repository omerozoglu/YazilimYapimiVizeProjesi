using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.Login {
    public class LoginQueryHandler : IRequestHandler<loginQuery, EntityResponse<User>> {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public LoginQueryHandler (IUserRepository userRepository, IMapper mapper) {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<EntityResponse<User>> Handle (loginQuery request, CancellationToken cancellationToken) {
            var response = new EntityResponse<User> () { ReponseName = nameof (loginQuery), Content = new List<User> () { } };
            var entity = await _userRepository.GetOneAsync (p => p.Username == request.Username && p.Password == request.Password);
            _mapper.Map<User> (entity);
            if (entity == null) {
                response.Status = ResponseType.Error;
                response.Message = $"No {nameof(User)} were found .";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(User)} get successfully.";
                response.Content.Add (entity);
            }
            return response;
        }
    }
}