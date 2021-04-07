using Shop.Host.Contexts;
using Shop.Host.Inferastructure.IRepositories;
using Shop.Host.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Host.Inferastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShopContext _context;

        public CategoryRepository(ShopContext context)
        {
            _context = context;
        }
        public int Delete(Category category)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Category> GetAll()
        {
            return _context.Category;
        }

        public Category GetById(int id)
        {
            return _context.Category.Find(id);
        }

        public IEnumerable<KeyValue> GetKeyValue()
        {
            return _context.Category.Select(x => new KeyValue { Value = x.Id, Key = x.Name });
        }

        public int Update(Category category)
        {
            _context.Category.Update(category);
            return _context.SaveChanges();
        }
    }
}
