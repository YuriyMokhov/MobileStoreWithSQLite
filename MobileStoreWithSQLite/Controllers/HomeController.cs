using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
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
        private readonly IMapper _mapper;
      //  private readonly IWebHostEnvironment _env;

        public HomeController(ILogger<HomeController> logger, MobileStoreContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            
        }

        public IActionResult Buy(int? id)
        {
            if (!id.HasValue) RedirectToAction("Index");
            var phone = _context.Phones.SingleOrDefault(x => x.Id == id);
            if (phone != null)
            {
                var vm = _mapper.Map<PhoneViewModel>(phone);
                return View(vm);
            }
              
            else throw new Exception($"Phone with id = {id} not found!");
            
        }

        [HttpPost]
        public IActionResult Add(PhoneViewModel newPhone)
        {
            var phone = _mapper.Map<Phone>(newPhone);
            _context.Phones.Add(phone);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

     
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var phone = _context.Phones.Single(x => x.Id == id.Value);
                var vm = _mapper.Map<PhoneViewModel>(phone);
                return View(vm);
            }
            else throw new Exception($"PhoneId is required for that operation!");

        }

  
        [HttpPost]
        public IActionResult Edit(PhoneViewModel editedPhone)
        {
            var phone =_context.Phones.SingleOrDefault(x => x.Id == editedPhone.Id);
            if(phone != null)
            {
                if (phone.Name != editedPhone.Name)
                    phone.Name = editedPhone.Name;
                //if (phone.Company != editedPhone.Company)
                //    phone.Company = editedPhone.Company;
                if (phone.Price != editedPhone.Price)
                    phone.Price = editedPhone.Price;

                _context.SaveChanges();
            }
            else throw new Exception($"Phone with id = {editedPhone.Id} not found!");

            return RedirectToAction("Index");
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            ViewBag.Title = "From Home Controller";
        }


        private void LoadFromCockies(IndexViewModel vm)
        {
            if (HttpContext.Request.Cookies.ContainsKey("IndexViewModelFilters.SelectedCompanyId"))
            {
                vm.IndexViewModelFilters.SelectedCompanyId = Convert.ToInt32(HttpContext.Request.Cookies["IndexViewModelFilters.SelectedCompanyId"]);
            }
            if (HttpContext.Request.Cookies.ContainsKey("IndexViewModelFilters.PartOfName"))
            {
                vm.IndexViewModelFilters.PartOfName = HttpContext.Request.Cookies["IndexViewModelFilters.PartOfName"];
            }
            if (HttpContext.Request.Cookies.ContainsKey("IndexViewModelSort.SelectedSort"))
            {
                vm.IndexViewModelSort.SelectedSort = Enum.Parse<SortPhonesBy>(HttpContext.Request.Cookies["IndexViewModelSort.SelectedSort"]);
            }

        }

        private void SaveToCockies(IndexViewModel vm)
        {
            HttpContext.Response.Cookies.Append("IndexViewModelFilters.SelectedCompanyId",
                    vm.IndexViewModelFilters.SelectedCompanyId.ToString());

         
            if (!string.IsNullOrEmpty(vm.IndexViewModelFilters.PartOfName))
                HttpContext.Response.Cookies.Append("IndexViewModelFilters.PartOfName",
                      vm.IndexViewModelFilters.PartOfName);

            //coockies
            HttpContext.Response.Cookies.Append("IndexViewModelSort.SelectedSort",
                    vm.IndexViewModelSort.SelectedSort.ToString());
        }

        [HttpGet]
        public IActionResult Index()
        {
            var vm = new IndexViewModel();
            var phones = _context.Phones.ToList();
            var companies = _context.Companies.ToList();

            LoadFromCockies(vm);

            vm.Phones = _mapper.Map<IList<PhoneViewModel>>(phones);
            vm.Companies = _mapper.Map<IList<CompanyViewModel>>(companies);
          
            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(IndexViewModel model)
        {
            var vm = new IndexViewModel();
            IList<Phone> phones;

            var companies = _context.Companies.ToList();


            SaveToCockies(model);
            
            if (model.IndexViewModelFilters.SelectedCompanyId == 0)
                phones = _context.Phones.ToList();
            else
            {
                phones = _context.Phones.Where(p => p.Company.Id == model.IndexViewModelFilters.SelectedCompanyId).ToList();
            }


            if (string.IsNullOrEmpty(model.IndexViewModelFilters.PartOfName))
                phones = _context.Phones.ToList();
            else
            {
                phones = _context.Phones.Where(p => p.Name.ToLower().Contains(model.IndexViewModelFilters.PartOfName.ToLower())).ToList();
            }

            //sorting
        

            if (Enum.IsDefined(typeof(SortPhonesBy), model.IndexViewModelSort.SelectedSort))
            {
                phones = model.IndexViewModelSort.SelectedSort switch
                {
                    SortPhonesBy.PriceAsc => phones = phones.OrderBy(p => p.Price).ToList(),
                    SortPhonesBy.PriceDesc => phones = phones.OrderByDescending(p => p.Price).ToList(),
                    SortPhonesBy.CompanyNameAsc => phones.OrderBy(p => p.Company.Name).ToList(),
                    SortPhonesBy.CompanyNameDesc => phones.OrderByDescending(p => p.Company.Name).ToList(),
                    SortPhonesBy.PhoneNameAsc => phones.OrderBy(p => p.Name).ToList(),
                    SortPhonesBy.PhoneNameDesc => phones.OrderByDescending(p => p.Name).ToList(),
                    _ => phones.OrderBy(p => p.Name).ToList()
                };
            }

           
            vm.Phones = _mapper.Map<IList<PhoneViewModel>>(phones);
            vm.Companies = _mapper.Map<IList<CompanyViewModel>>(companies);
            return View(vm);
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
