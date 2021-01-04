using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileStoreWithSQLite.Areas.Admin.Models.Domain;
using MobileStoreWithSQLite.Areas.Admin.Models.View;
using MobileStoreWithSQLite.Data;
using Newtonsoft.Json;

namespace MobileStoreWithSQLite.Areas.Admin.Controllers
{
  

    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly MobileStoreContext _context;
        private readonly IMapper _mapper;
        public AdminController(MobileStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
   
        }

        public IActionResult GetUsers()
        {
            var users = _mapper.Map<IList<User>, IList<UserViewModel>>(_context.Users.ToList());

            return Json(users);
        }
    }
}
