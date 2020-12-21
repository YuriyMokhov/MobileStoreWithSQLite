using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MobileStoreWithSQLite.Data;
using MobileStoreWithSQLite.Models.Domain;
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

        [HttpPost]
        public IActionResult Add(Phone newPhone)
        {
            _context.Phones.Add(newPhone);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        public IActionResult GetStatusCode()
        {
            return StatusCode(404);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var phone = _context.Phones.Single(x => x.Id == id.Value);
                return View(phone);
            }
            else throw new Exception($"PhoneId is required for that operation!");

        }

        [HttpPost]
        public IActionResult Edit(Phone editedPhone)
        {
            var phone =_context.Phones.SingleOrDefault(x => x.Id == editedPhone.Id);
            if(phone != null)
            {
                if (phone.Name != editedPhone.Name)
                    phone.Name = editedPhone.Name;
                if (phone.Company != editedPhone.Company)
                    phone.Company = editedPhone.Company;
                if (phone.Price != editedPhone.Price)
                    phone.Price = editedPhone.Price;

                _context.SaveChanges();
            }
            else throw new Exception($"Phone with id = {editedPhone.Id} not found!");

            return RedirectToAction("Index");
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
