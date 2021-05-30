using System.Threading.Tasks;
using ExchangeGateway.Models;
using ExchangeGateway.Models.EntityModels;

namespace ExchangeGateway.Services.Interfaces {
    public interface IAprpovalEntityService<T> where T : ApprovalEntityBase {
        Task<ResponseModel<T>> GetApprovalEntity (string id);
        Task<ResponseModel<T>> UpdateApprovalEntity (T model);
        Task<ResponseModel<T>> CreateApprovalEntity (T model);
    }
}