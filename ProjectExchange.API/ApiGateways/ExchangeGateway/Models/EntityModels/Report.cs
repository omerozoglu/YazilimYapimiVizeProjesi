using System;
using ExchangeGateway.Models.EntityModels.Enums;

namespace ExchangeGateway.Models.EntityModels {
    public class Report {
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public OperationType Operation { get; set; }
        public string ProductName { get; set; }
        public double Weight { get; set; }
        public double UnitPrice { get; set; }
    }
}