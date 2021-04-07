using Shop.Host.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Host.DTOs.Products
{
    public class GridResultDTO
    {
        public GridResultDTO(int count, ICollection<ProductListDTO> product)
        {
            Count = count;
            Product = product;
        }

        public int Count { get; set; }
        public ICollection<ProductListDTO> Product { get; set; }
    }
}
