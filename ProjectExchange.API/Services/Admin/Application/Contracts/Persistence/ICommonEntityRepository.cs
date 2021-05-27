using Domain.Common;
using Domain.Entities;

namespace Application.Contracts.Persistence {
    public interface ICommonEntityRepository<T> : IAsyncRepository<CommonEntity<T>> where T : ApprovalEntityBase {

    }
}