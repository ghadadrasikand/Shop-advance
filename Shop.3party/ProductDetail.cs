using System;
using System.Collections.Generic;

namespace Shop._3party
{
    public partial class ProductDetail
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
