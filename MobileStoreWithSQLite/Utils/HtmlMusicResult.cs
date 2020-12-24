using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting.Internal;
using MobileStoreWithSQLite.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace MobileStoreWithSQLite.Utils
{
    public class HtmlMusicResult : ViewResult
    {
        private readonly IWebHostEnvironment _env;
        public HtmlMusicResult(IWebHostEnvironment env)
        {
            _env = env;
            
        }
        public override Task ExecuteResultAsync(ActionContext context)
        {
            //   base.ExecuteResult(context);
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine("<audio controls>");
            sb.AppendLine($"<source src=\"../Blackfield - Go To Hell.mp3\" autoplay=\"autoplay\" type=\"audio/mpeg\">");
            sb.AppendLine("</audio>");
                //
            return Task.Run(() => {
                context.HttpContext.Response.Headers["Content-Type"] = "text/html; charset=UTF-8";
                context.HttpContext.Response.Body.WriteAsync(new ReadOnlyMemory<byte>(sb.ToString().ToList<char>().Select(x => (byte)x).ToArray()));

                });
            //return Task.Run(() =>
            //{
            //    var content = _html.Partial("_Audio", new Audio()
            //    {
            //        Name = "Tool",
            //        Src = "https://s155iva.storage.yandex.net/rdisk/5965cfd330bcb94a3d04ad9015f4a1fb89051ab20a8ae04b37aeddf962874df9/5fdb4650/C_bDBdTJ3KB3jYZ6nDSMv9skBomKL8Q7RW98DT4VDdw-BCdRMqczx10AaH1LSE0lDrDf01pZhNJQXEGhdz74qA==?uid=0&filename=Tool%20-%20Jambi.mp3&disposition=attachment&hash=JTJgBNq3iJlzo0VDq%2BHaPrUqrFGC2Hs%2B%2BjbVQ1iAw7ypERED9KIbXFZenG8S0/pVq/J6bpmRyOJonT3VoXnDag%3D%3D&limit=0&content_type=audio%2Fmpeg&owner_uid=23820219&fsize=17947415&hid=1cbcc78cc8af0ecce329bb151267a0e4&media_type=audio&tknv=v2&rtoken=HGNsqqAAd1ZC&force_default=no&ycrid=na-19c297860f1205818e8417042f0f4b54-downloader17f&ts=5b6a79da23400&s=981fd491192af1a681c7dcfcd66213e7431eb984e91492a17bec02b7bcc95b7e&pb=U2FsdGVkX1_-4zWF2rJiMr_kVAIfFtfEfEbgeO2cPik0bg_oRpALQtBIDgcPSKp6cRFQAQT8akTIWuUeXQpqjpnrtErLbNmngRWXp1DCgko"
            //    });



            //    context.HttpContext.Response.BodyWriter.WriteAsync(new ReadOnlyMemory<byte>(content.ToString().ToList<char>().Select(x => (byte)x).ToArray()));
            //});


        }
    }
}
