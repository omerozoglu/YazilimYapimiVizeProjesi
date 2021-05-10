using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.UpdateCommand {
    public class UpdateCommonEntityCommandHandler : IRequestHandler<UpdateCommonEntityCommand, bool> {

        private readonly ICommonEntityRepository _commonEntityrepository;
        private readonly IMapper _mapper;

        public UpdateCommonEntityCommandHandler (ICommonEntityRepository commonEntityrepository, IMapper mapper) {
            _commonEntityrepository = commonEntityrepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle (UpdateCommonEntityCommand request, CancellationToken cancellationToken) {
            var commonEntityToUpdate = await _commonEntityrepository.GetByIdAsync (request.Id);
            if (commonEntityToUpdate == null) {
                return false;
            }
            _mapper.Map (request, commonEntityToUpdate, typeof (UpdateCommonEntityCommand), typeof (CommonEntity));
            await _commonEntityrepository.UpdateAsync (commonEntityToUpdate);
            return true;
        }
    }
}