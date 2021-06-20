using ExchangeGateway.Models.EntityModels;
using ExchangeGateway.Models.EntityModels.Enums;

namespace Domain.Entities {
    public class MoneyApproval : ApprovalEntityBase {
        public double Deposit { get; set; }
        public CurrencyType Currency { get; set; }
    }
}