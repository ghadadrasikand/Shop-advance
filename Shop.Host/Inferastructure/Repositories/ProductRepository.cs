using Shop.Host.Contexts;
using Shop.Host.Inferastructure.IRepositories;
using Shop.Host.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Host.Inferastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopContext _db;
        public ProductRepository(ShopContext db)
        {
            _db = db;
        }
        public List<Product> GetAll()
        {
            return _db.Product.ToList();
        }
        public IQueryable<Product> GetById(int id)
        {
            return _db.Product.Where(x => x.Id == id && x.IsDeleted == false);
        }
        public List<Product> GetPaging(int skip, int take)
        {
            return _db.Product.Skip(skip).Take(take).ToList();
        }
        public int GetCount()
        {
            return _db.Product.Count();
        }

        public int Insert(Product product)
        {
            _db.Product.Add(product);
            return _db.SaveChanges();
        }
    }
}
