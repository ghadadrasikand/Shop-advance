using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Host.ApplicationServices.IServices;
using Shop.Host.DTOs.Products;
using Shop.Host.Models;

namespace Shop.Host.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Route("Panel/[Controller]/[Action]")]
    public class ProductPanelController : Controller
    {
        private readonly IProductService ProductService;
        public ProductPanelController(IProductService productService)
        {
            ProductService = productService;
        }

        [HttpGet]
        [Route("~/")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("{skip}/{take}")]
        public IActionResult ProductList(int skip, int take)
        {
            var result = ProductService.GetPaging(skip, take);
            return View(result);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            var dto = ProductService.GetCategoryList();
            return View(dto);
        }

        [HttpPost]
        public IActionResult Insert([FromForm] ProductPanelInsertDTO dto)
        {
            if (ModelState.IsValid)
            {
                var result = ProductService.Insert(dto);
                if (result)
                {
                    return RedirectToAction("ProductList", new { skip = 0, take = 10 });
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            else
            {
                return View("AddProduct", dto);
            }

        }

        [HttpGet("{id}")]
        public IActionResult UpdateProduct(int id)
        {
            var dto = ProductService.GetForUpdateById(id);
            return View(dto);
        }

        [HttpPut]
        public IActionResult Update([FromForm] ProductPanelUpdateDTO dto)
        {
            if (ModelState.IsValid)
            {

                var result = ProductService.Update(dto);
                if (result)
                {
                    return RedirectToAction("ProductList", new { skip = 0, take = 10 });
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            else
            {
                return View("UpdateProduct", dto);
            }

        }
    }
}