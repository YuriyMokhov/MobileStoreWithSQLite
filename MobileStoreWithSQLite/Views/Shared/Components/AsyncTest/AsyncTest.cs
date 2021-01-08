using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MobileStoreWithSQLite.Views.Shared.Components.AsyncTest
{
    public class AsyncTest : ViewComponent
    {
        public async Task<string> InvokeAsync()
        {
            await Task.Run(()=> Thread.Sleep(10000));
            return "Тут я выполнял долгую операцию и устал. Теперь я грууустный панда. Я выполнял её без ajax, поэтому я ждал 10 сек!";
        } 
    }
}
