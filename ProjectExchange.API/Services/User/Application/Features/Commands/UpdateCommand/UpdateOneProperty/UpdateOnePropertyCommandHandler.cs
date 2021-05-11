using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using MediatR;

namespace Application.Features.Commands.UpdateCommand.UpdateOneProperty {
    public class UpdateOnePropertyCommandHandler : IRequestHandler<UpdateOnePropertyCommand, bool> {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateOnePropertyCommandHandler (IUserRepository userRepository, IMapper mapper) {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle (UpdateOnePropertyCommand request, CancellationToken cancellationToken) {
            var userToUpdate = await _userRepository.GetByIdAsync (request.Id);
            if (userToUpdate == null) {
                return false;
            }
            var updateOneProp = new UpdateOnePropModel () { Id = userToUpdate.Id, Property = request.Property, Value = request.Value };
            _mapper.Map (request, updateOneProp, typeof (UpdateOnePropertyCommand), typeof (UpdateOnePropModel));
            await _userRepository.UpdateOnePropertyUser (request.Id, request.Property, request.Value);
            return true;
        }
    }
}