using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStoreWithSQLite.Services
{
    public interface ICustomService
    {
        string Message { get;}
    }

    public class CustomService : ICustomService
    {
        public string Message { get => "Custom service was injected"; }
    }
}
