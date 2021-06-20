using ExchangeGateway.Models.EntityModels;
using ExchangeGateway.Models.EntityModels.Enums;

namespace Domain.Entities {
    public class ProductApproval : ApprovalEntityBase {
        public string ProductName { get; set; }
        public string ProductImgUrl { get; set; }
        public double ProductWeight { get; set; }
    }
}