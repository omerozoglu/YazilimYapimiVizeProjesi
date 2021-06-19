using Domain.Common;
using Domain.Entities.Enums;

namespace Domain.Entities {
    public class Report : EntityBase {
        public OperationType Operation { get; set; }
    }
}