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

        public IActionResult GetStatusCode(int code)
        {
            return StatusCode(code);
        }
    }
}//http://localhost:5001/service/GetStatusCode/301
