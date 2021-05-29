using Domain.Common;
using Domain.Entities;

namespace Application.Contracts.Persistence {
    public interface IApprovalEntityRepository<T> : IAsyncRepository<T> where T : ApprovalEntityBase {

    }
}