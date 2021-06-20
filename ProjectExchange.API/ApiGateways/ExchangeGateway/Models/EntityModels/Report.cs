using System;
using Domain.Entities.Enums;

namespace Domain.Entities {
    public class Report {
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public OperationType Operation { get; set; }
        public string ProductName { get; set; }
        public double Weight { get; set; }
        public double UnitPrice { get; set; }
    }
}