﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStoreWithSQLite.Models.Domain
{
    public class Phone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Company Company { get; set; }
        public int Price { get; set; }
    }
}
