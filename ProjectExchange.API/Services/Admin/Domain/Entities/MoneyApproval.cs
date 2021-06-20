using Domain.Common;
using Domain.Common.Enums;

namespace Domain.Entities {
    public class MoneyApproval : ApprovalEntityBase {
        public double Deposit { get; set; }
        public CurrencyType Currency { get; set; }
    }
}