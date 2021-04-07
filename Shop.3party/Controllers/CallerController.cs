using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shop._3party.Inferastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop._3party.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CallerController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public CallerController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("GetProduct")]
        public IActionResult Get()
        {
            var response = _productRepository.GetAll();
            return Ok(response);
        }
    }
}
