using Shop.Host.DTOs.Products;
using Shop.Host.Models;
using System.Collections.Generic;

namespace Shop.Host.ApplicationServices.IServices
{
    public interface IProductService
    {
        List<Product> GetAll();
        ProductPanelUpdateDTO GetForUpdateById(int id);
        GridResultDTO GetPaging(int skip, int take);
        ProductPanelInsertDTO GetCategoryList();
        bool Insert(ProductInsertDTO dto);
        bool Insert(ProductPanelInsertDTO dto);
        bool Update(ProductPanelUpdateDTO dto);
    }
}
