using Domain.Common;
using Domain.Entities.Enums;

namespace Domain.Entities {
    public class Report : EntityBase {
        public OperationType Operation { get; set; }
        public string ProductName { get; set; }
        public double Weight { get; set; }
        public double UnitPrice { get; set; }
    }
}