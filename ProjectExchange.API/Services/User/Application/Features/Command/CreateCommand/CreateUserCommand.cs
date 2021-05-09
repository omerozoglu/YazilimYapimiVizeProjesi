using Application.Models;
using MediatR;

namespace Application.Features.Command.CreateCommand {
    public class CreateUserCommand : IRequest<bool> {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int AccountType { get; set; }
        public string TCNumber { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}