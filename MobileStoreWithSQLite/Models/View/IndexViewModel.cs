using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStoreWithSQLite.Models.View
{
    public class IndexViewModel
    {
        public IEnumerable<PhoneViewModel> Phones { get; set; }
        public IEnumerable<CompanyViewModel> Companies { get; set; }
        public IndexViewModelFilters IndexViewModelFilters { get; set; }
        public IndexViewModelSort IndexViewModelSort { get; set; }
        public IEnumerable<SortPhonesBy> SortPhonesByList { get; set; }

        public IndexViewModel()
        {
            //get
            Phones = new List<PhoneViewModel>();
            Companies = new List<CompanyViewModel>();
            SortPhonesByList = Enum.GetValues(typeof(SortPhonesBy)).Cast<SortPhonesBy>();
            //post
            IndexViewModelFilters = new IndexViewModelFilters();
            IndexViewModelSort = new IndexViewModelSort();
          
        }
    }

    public class IndexViewModelFilters
    {
        public int SelectedCompanyId { get; set; }
        public string PartOfName { get; set; }


    }
    public class IndexViewModelSort
    {
        public SortPhonesBy SelectedSort { get; set; }
    }


    public enum SortPhonesBy
    {
        [Description("Цена (по возростанию)")]
        PriceAsc = 1,
        [Description("Цена (по убыванию)")]
        PriceDesc = 2,
        [Description("Навание компании (по возростанию)")]
        CompanyNameAsc = 3,
        [Description("Навание компании (по убыванию)")]
        CompanyNameDesc = 4,
        [Description("Имя (по возростанию)")]
        PhoneNameAsc = 5,
        [Description("Имя (по убыванию)")]
        PhoneNameDesc = 6
    }

 
}
