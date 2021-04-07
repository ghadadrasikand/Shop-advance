using Shop.Host.ApplicationServices.IServices;
using Shop.Host.DTOs.Categories;
using Shop.Host.Inferastructure.IRepositories;
using Shop.Host.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Host.ApplicationServices.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository Repository;

        public CategoryService(ICategoryRepository repository)
        {
            Repository = repository;
        }

        public List<Category> GetAll()
        {
            return Repository.GetAll().ToList();
        }

        public CategoryMultiSelectDTO GetForMultiSelect()
        {
            var category = Repository.GetKeyValue().ToList();
            var result = new CategoryMultiSelectDTO
            {
                Categories = category
            };
            
            return result;
        }
    }
}
