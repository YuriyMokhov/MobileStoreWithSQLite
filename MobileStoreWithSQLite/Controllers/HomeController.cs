using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MobileStoreWithSQLite.Data;
using MobileStoreWithSQLite.Models.View;

namespace MobileStoreWithSQLite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MobileStoreContext _context;

        public HomeController(ILogger<HomeController> logger, MobileStoreContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Buy(int? id)
        {
            if (!id.HasValue) RedirectToAction("Index");
            var phone = _context.Phones.SingleOrDefault(x => x.Id == id);
            if (phone != null)
                return View(phone);
            else throw new Exception($"Phone with id = {id} not found!");
            
        }
        public IActionResult Index()
        {
            
             var phones = _context.Phones.ToList();
            return View(phones);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
