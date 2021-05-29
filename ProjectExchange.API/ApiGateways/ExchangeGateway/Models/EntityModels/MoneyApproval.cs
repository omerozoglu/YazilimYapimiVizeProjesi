using ExchangeGateway.Models.EntityModels;

namespace Domain.Entities {
    public class MoneyApproval : ApprovalEntityBase {
        public double Deposit { get; set; }
    }
}