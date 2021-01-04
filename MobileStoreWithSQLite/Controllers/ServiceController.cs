using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace MobileStoreWithSQLite.Controllers
{
    public class ServiceController : Controller
    {
        [HttpGet]
        public IActionResult GetPhysicalFile([FromServices] IWebHostEnvironment env)
        {
            return PhysicalFile(Path.Combine(env.ContentRootPath, "Files\\Clr.pdf"), "application/pdf", "Clr.pdf");
        }

        [HttpGet]
        public IActionResult GetVirtualFile()
        {
            return File("Clr.pdf", "application/pdf", "Clr.pdf");
        }


        [Route("/Service/StatusCode/{code?}")]
        public IActionResult GetStatusCode(int code)
        {
            return StatusCode(code);
        }

     
        public IActionResult Fallback()
        {
            var cr =  this.Content("Fallback routing!");
            cr.StatusCode = 500;
            return cr;
        }
    }
}//http://localhost:5001/service/GetStatusCode/301
