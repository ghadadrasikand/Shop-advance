using Shop.Host.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Host.Inferastructure.IRepositories
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        IQueryable<Product> GetById(int id);
        List<Product> GetPaging(int skip, int take);
        int GetCount();
        int Insert(Product product);
    }
}
