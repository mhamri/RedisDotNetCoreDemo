using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Demo3.Models;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace Demo3.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDistributedCache _cache;


        public HomeController(IDistributedCache cache)
        {
            _cache = cache;
        }
        public async Task<IActionResult> Index()
        {
            var cacheKey = "withoutExpiration";

            var datetime = await _cache.GetAsync(cacheKey);

            string dateTimeStr;
            if (datetime==null)
            {
                dateTimeStr = DateTime.Now.ToString(CultureInfo.InvariantCulture);

                await _cache.SetAsync(cacheKey, Encoding.UTF8.GetBytes(dateTimeStr));
            }
            else
            {
                dateTimeStr = Encoding.UTF8.GetString(datetime);
            }


            return View("Index", dateTimeStr );

        }


        public async Task<IActionResult> SlidingExpiration()
        {
            var cacheKey = "withSlidingExpiration";

            var datetime = await _cache.GetAsync(cacheKey);

            string dateTimeStr;
            if (datetime==null)
            {
                dateTimeStr = DateTime.Now.ToString(CultureInfo.InvariantCulture);

                await _cache.SetAsync(cacheKey, Encoding.UTF8.GetBytes(dateTimeStr),
                    new DistributedCacheEntryOptions()
                    {
                        SlidingExpiration = TimeSpan.FromSeconds(10)
                    }
                );
            }
            else
            {
                dateTimeStr = Encoding.UTF8.GetString(datetime);
            }

            return View("Index", dateTimeStr);

        }


    }
}
