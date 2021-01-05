using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStoreWithSQLite.Models.View
{
    public class IndexViewModel
    {
        public IEnumerable<PhoneViewModel> Phones { get; set; }
        public IEnumerable<CompanyViewModel> Companies { get; set; }
        // public IndexViewModelFilters IndexViewModelFilters { get; set; }
        public int SelectedCompanyId { get; set; }
    }

    public class IndexViewModelFilters
    {
        public CompanyViewModel SelectedCompany { get; set; }
    }
}
