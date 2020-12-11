using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStoreWithSQLite.Data
{
    public abstract class DbOptionsFactory
    {
        public abstract DbContextOptionsBuilder Configuration(DbContextOptionsBuilder options, IConfiguration configuration);
    }

    public class SqlServerOptionsFactory : DbOptionsFactory
    {
        public override DbContextOptionsBuilder Configuration(DbContextOptionsBuilder options, IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("DefaultConnection");
            return options.UseSqlServer(connection);

        }
    }

    public class SQLiteOptionsFactory : DbOptionsFactory
    {
        public override DbContextOptionsBuilder Configuration(DbContextOptionsBuilder options, IConfiguration configuration)
        {
            return options.UseSqlite("Data Source=MobileStore.db");
        }
    }
}
