using Microsoft.EntityFrameworkCore;
using MobileStoreWithSQLite.Areas.Admin.Models.Domain;

namespace MobileStoreWithSQLite.Data
{
    public partial class MobileStoreContext
    {
        public DbSet<User> Users { get; set; }
    }
}
