using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Host.Extensions;

namespace Shop.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormSampleController : ControllerBase
    {

        [HttpPost]
        [Route("OnPostForm")]
        public IActionResult OnPostForm([FromForm] IFormFile frm)
        {
            string cdn = "C:\\";
            string path = "TestImage";
            var imagePath = ImageExtension.SaveToCdn(frm, cdn, path);
            return Ok();
        }
    }
}
