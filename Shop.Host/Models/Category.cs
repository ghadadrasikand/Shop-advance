using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Host.Models
{
    public class Category : BaseEntity
    {
        public Category()
        {
            ProductCategory = new HashSet<ProductCategory>();
        }
        public int Id { get; set; }
        [Required, StringLength(128)]
        public string Name { get; set; }
        public ICollection<ProductCategory> ProductCategory { get; set; }

    }
}
