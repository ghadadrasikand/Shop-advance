using System;
using System.Collections.Generic;

namespace Shop._3party
{
    public partial class Category
    {
        public Category()
        {
            ProductCategory = new HashSet<ProductCategory>();
        }

        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProductCategory> ProductCategory { get; set; }
    }
}
