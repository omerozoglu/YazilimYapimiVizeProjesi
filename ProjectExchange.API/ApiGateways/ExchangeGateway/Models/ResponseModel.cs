using System.Collections.Generic;

namespace ExchangeGateway.Models {
    public class ResponseModel<T> {
        public string ReponseName { get; set; }
        public ResponseStatus Status { get; set; }
        public string Message { get; set; }
        public List<T> Content { get; set; }
    }
}