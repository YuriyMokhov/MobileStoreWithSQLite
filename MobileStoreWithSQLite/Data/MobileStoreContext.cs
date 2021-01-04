using Microsoft.EntityFrameworkCore;
using MobileStoreWithSQLite.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStoreWithSQLite.Data
{
    public partial class MobileStoreContext : DbContext
    {

        public MobileStoreContext(DbContextOptions options)
           : base(options)
        {
            Database.EnsureCreated();
     
        }


        public DbSet<Phone> Phones { get; set; }
        public DbSet<Order> Orders { get; set; }
    }

  
}
