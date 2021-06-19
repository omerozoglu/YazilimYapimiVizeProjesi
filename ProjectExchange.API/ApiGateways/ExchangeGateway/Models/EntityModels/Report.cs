using System;
using Domain.Entities.Enums;

namespace Domain.Entities {
    public class Report {
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public OperationType Operation { get; set; }
    }
}