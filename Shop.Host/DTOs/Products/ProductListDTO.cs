using Shop.Host.Models.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Host.DTOs.Products
{
    public class ProductListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        private string imagePath;
        public string ImagePath { 
            get { return HttpOptions.HttpProductImagePath + imagePath; } 
            set { imagePath=value; } 
        }
    }
}
