using Microsoft.AspNetCore.Mvc;
using MobileStoreWithSQLite.Views.Shared.Components.Timer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStoreWithSQLite.Components
{
    public class Timer : ViewComponent
    {
        public IViewComponentResult Invoke(string themeName)
        {
            // return $"Текущее время: {DateTime.Now.ToString("hh:mm:ss")}";
            return View("Timer", new TimerOptions() { ThemeName = themeName });
        }
    }
}
