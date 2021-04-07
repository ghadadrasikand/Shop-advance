using Shop._3party.Inferastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop._3party.Inferastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopDBTorfeContext context;
        public ProductRepository(ShopDBTorfeContext context)
        {
            this.context = context;
        }
        public List<Product> GetAll()
        {
            return context.Product.ToList();
        }
    }
}
