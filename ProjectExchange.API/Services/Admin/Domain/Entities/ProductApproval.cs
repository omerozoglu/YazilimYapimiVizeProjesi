using Domain.Common;
using Domain.Common.Enums;

namespace Domain.Entities {
    public class ProductApproval : ApprovalEntityBase {
        public string ProductName { get; set; }
        public string ProductImgUrl { get; set; }
        public double ProductWeight { get; set; }
    }
}