namespace ExchangeGateway.Models.EntityModels {
    public class Product {
        public string Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public string ImgUrl { get; set; }
        public double Weight { get; set; }
        public double UnitPrice { get; set; }
        public int Status { get; set; }
    }
}