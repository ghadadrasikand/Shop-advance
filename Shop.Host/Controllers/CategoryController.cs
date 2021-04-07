using System;
using Microsoft.AspNetCore.Mvc;
using Shop.Host.ApplicationServices.IServices;
using Shop.Host.DTOs.Categories;
using Shop.Host.Filters;
using Shop.Host.Inferastructure.IRepositories;
using Shop.Host.Models;

namespace Shop.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SecurityFilter(ApplicationRolesConst.ApplicationUser)]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repository;
        private readonly IUserContext _userContext;

        public CategoryController(ICategoryRepository repository, IUserContext userContext)
        {
            _repository = repository;
            _userContext = userContext;
        }

        [HttpPut]
        public IActionResult Update(CategoryUpdateDTO category)
        {
            var cat = _repository.GetById(category.Id);
            cat.Name = category.Name;
            cat.ModifiedDate = DateTime.Now;
            cat.UserId = _userContext.UserId;
            int result = _repository.Update(cat);
            if (result > 0)
            {
                return Ok();
            }
            else
            {
                throw new Exception();

            }
        }
    }
}