namespace Shop.Host.Models
{
    public class ProductDetail
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
