using Shop.Host.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Host.DTOs.Categories
{
    public class CategoryMultiSelectDTO
    {
        public CategoryMultiSelectDTO()
        {
            Categories = new HashSet<KeyValue>();
            CategoryIds = new List<int>();
        }
        public List<int> CategoryIds { get; set; }
        public ICollection<KeyValue> Categories { get; set; }
    }
}
