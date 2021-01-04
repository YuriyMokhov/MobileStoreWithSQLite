using MobileStoreWithSQLite.Areas.Admin.Models.Domain;
using MobileStoreWithSQLite.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStoreWithSQLite.Data
{
    public class SampleData
    {
        public static void Initialize(MobileStoreContext context)
        {
            if (!context.Phones.Any())
            {
                context.Phones.AddRange(
                    new Phone
                    {
                        Name = "iPhone X",
                        Company = "Apple",
                        Price = 600
                    },
                    new Phone
                    {
                        Name = "Samsung Galaxy Edge",
                        Company = "Samsung",
                        Price = 550
                    },
                    new Phone
                    {
                        Name = "Pixel 3",
                        Company = "Google",
                        Price = 500
                    }
                );
                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User
                    {
                        FirstName = "Yuriy",
                        LastName = "Mokhov",
                        Year = 1986
                    },
                    new User
                    {
                        FirstName = "Alexandr",
                        LastName = "Poltorabatko",
                        Year = 1986
                    }
                    );

                context.SaveChanges();
            }
        }
    }
}

