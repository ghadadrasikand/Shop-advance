using Shop.Host.DTOs.Categories;
using Shop.Host.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Host.ApplicationServices.IServices
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        CategoryMultiSelectDTO GetForMultiSelect();
    }
}
