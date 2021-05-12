using System.Collections.Generic;

namespace Domain.Common {
    public class EntityResponse<T> where T : EntityBase {
        public string ReponseName { get; set; }
        public ResponseType Status { get; set; }
        public string Message { get; set; }
        public List<T> Content { get; set; }
    }
}