﻿using MobileStoreWithSQLite.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStoreWithSQLite.Models.View
{
    public class PhoneViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CompanyViewModel Company { get; set; }
        public int Price { get; set; }
    }


}
