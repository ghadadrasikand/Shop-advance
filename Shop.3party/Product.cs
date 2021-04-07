using System;
using System.Collections.Generic;

namespace Shop._3party
{
    public partial class Product
    {
        public Product()
        {
            ProductCategory = new HashSet<ProductCategory>();
            ProductDetail = new HashSet<ProductDetail>();
        }

        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImagePath { get; set; }

        public virtual ICollection<ProductCategory> ProductCategory { get; set; }
        public virtual ICollection<ProductDetail> ProductDetail { get; set; }
    }
}
