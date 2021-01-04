using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileStoreWithSQLite.Data;

namespace MobileStoreWithSQLite.Areas.Controllers
{
  
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly MobileStoreContext _context;
        public AdminController(MobileStoreContext context)
        {
            _context = context;
        }
        public IActionResult GetUsers()
        {
            
        }
    }
}
