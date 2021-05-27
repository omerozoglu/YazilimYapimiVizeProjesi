using System.Threading.Tasks;
using ExchangeGateway.Models;
using ExchangeGateway.Models.EntityModels;

namespace ExchangeGateway.Services.Interfaces {
    public interface ICommonEntityService {
        Task<ResponseModel<CommonEntity>> GetCommonEntity (string id);
        Task<ResponseModel<CommonEntity>> UpdateCommonEntity (CommonEntity model);
        Task<ResponseModel<CommonEntity>> CreateCommonEntity (CommonEntity model);
    }
}