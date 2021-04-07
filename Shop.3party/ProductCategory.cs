using System;
using System.Collections.Generic;

namespace Shop._3party
{
    public partial class ProductCategory
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CategoryId { get; set; }
        public int ProductId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Product Product { get; set; }
    }
}
