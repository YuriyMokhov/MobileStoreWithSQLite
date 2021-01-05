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
            if (!context.Companies.Any())
            {
                var apple = new Company
                {
                    Name = "Apple",
                    Country = "U.S.A"
                };
                var google = new Company
                {
                    Name = "Google",
                    Country = "U.S.A"
                };
                var samsung = new Company
                {
                    Name = "Samsung",
                    Country = "South Korea"
                };

                context.Companies.AddRange(
                    apple
                    , google
                    , samsung
                    );


                context.Phones.AddRange(
                    new Phone
                    {
                        Name = "iPhone X",
                        Company = apple,
                        Price = 600
                    },
                       new Phone
                       {
                           Name = "iPhone 8S",
                           Company = apple,
                           Price = 600
                       },
                    new Phone
                    {
                        Name = "Samsung Galaxy Edge",
                        Company = samsung,
                        Price = 550
                    },
                     new Phone
                     {
                         Name = "Samsung Galaxy Note",
                         Company = samsung,
                         Price = 550
                     },
                    new Phone
                    {
                        Name = "Pixel 3",
                        Company = google,
                        Price = 500
                    },
                     new Phone
                     {
                         Name = "Pixel 4",
                         Company = google,
                         Price = 700
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

