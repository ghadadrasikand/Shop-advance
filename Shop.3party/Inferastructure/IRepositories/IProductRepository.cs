using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop._3party.Inferastructure.IRepositories
{
    public interface IProductRepository
    {
        List<Product> GetAll();
    }
}
