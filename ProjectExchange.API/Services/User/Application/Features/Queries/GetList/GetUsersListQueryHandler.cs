using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.GetList {
    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, EntityResponse<User>> {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUsersListQueryHandler (IUserRepository userRepository, IMapper mapper) {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<EntityResponse<User>> Handle (GetUsersListQuery request, CancellationToken cancellationToken) {
            var response = new EntityResponse<User> () { ReponseName = nameof (GetUsersListQuery), Content = new List<User> () { } };
            var userList = await _userRepository.GetAllAsync ();
            _mapper.Map<List<User>> (userList);
            if (userList == null) {
                response.Status = ResponseType.Error;
                response.Message = $"No {nameof(User)}s were found .";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(User)}s get successfully.";
                response.Content.AddRange (userList);
            }
            return response;
        }
    }
}