using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.Login {
    public class loginQuery : IRequest<EntityResponse<User>> {
        public loginQuery (string username, string password) {
            Username = username;
            Password = password;
        }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}