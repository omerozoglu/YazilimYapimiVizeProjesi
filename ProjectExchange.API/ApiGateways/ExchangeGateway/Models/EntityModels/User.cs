using System.Collections.Generic;

namespace ExchangeGateway.Models.EntityModels {
    public class User {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<int> AccountType { get; set; }
        public string TCNumber { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public double Credit { get; set; }
        public List<string> Products { get; set; }
    }
}