using Microsoft.Extensions.Options;
using Shop.Host.Models.Options;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Host.Models
{
    public class Product : BaseEntity
    {
        public Product()
        {
            ProductDetail = new HashSet<ProductDetail>();
            ProductCategory = new HashSet<ProductCategory>();
        }
        public int Id { get; set; }
        [Required, StringLength(128)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImagePath { get; set; }
        public ICollection<ProductDetail> ProductDetail { get; set; }
        public ICollection<ProductCategory> ProductCategory { get; set; }
    }
}
