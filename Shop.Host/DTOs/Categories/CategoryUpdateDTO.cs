using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Host.DTOs.Categories
{
    public class CategoryUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required, StringLength(128)]
        public string Name { get; set; }
    }
}
