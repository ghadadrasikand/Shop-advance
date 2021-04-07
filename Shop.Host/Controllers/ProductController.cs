using Microsoft.AspNetCore.Mvc;
using Shop.Host.ApplicationServices.IServices;
using Shop.Host.DTOs.Products;
using Shop.Host.Filters;
using Shop.Host.Models;
using System;

namespace Shop.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService ProductService;
        public ProductController( IProductService productService)
        {
            ProductService = productService;
        }

        //[SecurityFilter(ApplicationRolesConst.ApplicationUser)]
        [HttpGet]
        [Route("GetProducts")]
        public IActionResult GetProducts()
        {
            var result = ProductService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetPaging/{skip}/{take}")]
        public IActionResult GetPaging(int skip, int take)
        {
            var result = ProductService.GetPaging(skip,take);
            return Ok(result);
        }

        [HttpPost]
        [Route("Insert")]
        public IActionResult Insert([FromForm] ProductInsertDTO dto)
        {
            var result = ProductService.Insert(dto);
            if (result)
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