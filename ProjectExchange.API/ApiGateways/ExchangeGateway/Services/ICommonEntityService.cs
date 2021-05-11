using System.Threading.Tasks;
using ExchangeGateway.Models;

namespace ExchangeGateway.Services {
    public interface ICommonEntityService {
        Task<CommonEntityModel> GetCommonEntity (string id);
        Task<bool> UpdateCommonEntity (CommonEntityModel model);
    }
}