﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using MobileStoreWithSQLite.Areas.Admin.Models.Domain;
using MobileStoreWithSQLite.Areas.Admin.Models.View;
using MobileStoreWithSQLite.Models.Domain;
using MobileStoreWithSQLite.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStoreWithSQLite.Utils
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Phone, PhoneViewModel>();
            CreateMap<PhoneViewModel, Phone>();
            CreateMap<User, UserViewModel> ();
            CreateMap<UserViewModel, User>();
            CreateMap<Company, CompanyViewModel>();
            CreateMap<CompanyViewModel, Company>();
            CreateMap<SelectListItem, CompanyViewModel>();
        }
    }
}
