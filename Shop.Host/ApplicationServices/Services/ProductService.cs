using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Shop.Host.ApplicationServices.IServices;
using Shop.Host.DTOs.Products;
using Shop.Host.Extensions;
using Shop.Host.Inferastructure.IRepositories;
using Shop.Host.Models;
using Shop.Host.Models.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Host.ApplicationServices.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly ICategoryService CategoryService;
        private readonly CDNConfig CDNConfig;
        public ProductService(IProductRepository repository, IOptions<CDNConfig> cDNConfig, ICategoryService categoryService)
        {
            _repository = repository;
            CDNConfig = cDNConfig.Value;
            CategoryService = categoryService;
        }

        public List<Product> GetAll()
        {
            return _repository.GetAll();
        }

        public ProductPanelUpdateDTO GetForUpdateById(int id)
        {
            var product = _repository.GetById(id).Include(x => x.ProductCategory).FirstOrDefault();

            var categories = CategoryService.GetForMultiSelect();
            categories.CategoryIds = product.ProductCategory.Select(x => x.CategoryId).ToList();

            var result = new ProductPanelUpdateDTO
            {
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                ImagePath = product.ImagePath,
                CategoryMultiSelectDTO = categories
            };
            return result;
        }

        public ProductPanelInsertDTO GetCategoryList()
        {
            var categories = CategoryService.GetForMultiSelect();
            var dto = new ProductPanelInsertDTO
            {
                CategoryMultiSelectDTO = categories
            };
            return dto;
        }

        public GridResultDTO GetPaging(int skip, int take)
        {
            int count = _repository.GetCount();
            var data = _repository.GetPaging(skip, take);

            var productDTO = data.Select(x => new ProductListDTO
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Quantity = x.Quantity,
                ImagePath = x.ImagePath
            }).ToList();

            return new GridResultDTO(count, productDTO);
        }

        public bool Insert(ProductInsertDTO dto)
        {
            bool result = false;
            var imagePath = ImageExtension.SaveToCdn(dto.Img, CDNConfig.Cdn, CDNConfig.Path);
            var pr = new Product()
            {
                Name = dto.Name,
                Price = dto.Price,
                Quantity = dto.Quantity,
                ImagePath = imagePath
            };

            int inserted = _repository.Insert(pr);
            if (inserted > 0)
            {
                result = true;
            }
            return result;
        }

        public bool Insert(ProductPanelInsertDTO dto)
        {
            bool result = false;

            var imagePath = ImageExtension.SaveTowwwroot(dto.Img, "Product");

            var pdlist = new List<ProductCategory>();
            if (dto.CategoryMultiSelectDTO.CategoryIds != null && dto.CategoryMultiSelectDTO.CategoryIds.Count > 0)
            {
                foreach (var categoryId in dto.CategoryMultiSelectDTO.CategoryIds)
                {
                    var pd = new ProductCategory
                    {
                        CategoryId = categoryId
                    };

                    pdlist.Add(pd);
                }
            }

            var pr = new Product()
            {
                Name = dto.Name,
                Price = dto.Price,
                Quantity = dto.Quantity,
                ImagePath = imagePath,
                ProductCategory = pdlist
            };

            int inserted = _repository.Insert(pr);
            if (inserted > 0)
            {
                result = true;
            }
            return result;
        }

        public bool Update(ProductPanelUpdateDTO dto)
        {
            bool result = false;
            //TodoGetById
            //Map Dto To Model
            //Remove All Category If Deleted
            //Add All Category If Added
            //Update
            return result;
        }
    }
}
