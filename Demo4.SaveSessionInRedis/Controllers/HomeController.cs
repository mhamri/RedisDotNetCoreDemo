using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Demo4.SaveSessionInRedis.Controllers
{
    public class HomeController : Controller
    {
        //https://joonasw.net/view/redis-cache-session-store
        public async Task<IActionResult> Index()
        {
            await HttpContext.Session.LoadAsync();
            //Get value from session
            string storedValue = HttpContext.Session.GetString("TestValue");
            if (storedValue == null)
            {
                //No value stored, set one
                storedValue = "set session in home: " + DateTime.Now.ToString("s");
                HttpContext.Session.SetString("TestValue", storedValue);
                //Store session data asynchronously
                await HttpContext.Session.CommitAsync();
            }

            return View("Index", storedValue);
        }
  
        public IActionResult SetSession()    
        {    
            HttpContext.Session.SetString("seperateset","set session in SetSession: " + DateTime.Now.ToString("s"));    
            return View("Index", "set session is complete!");    
        }    
 
        public async Task<IActionResult> GetSession()    
        {    
            //Load data from distributed data store asynchronously
            await HttpContext.Session.LoadAsync();
            var storedValue = HttpContext.Session.GetString("seperateset");    
            return View("Index", storedValue); 
        }  

        
        public IActionResult Error()
        {
            return View("Index", "error happened!");
        }
    }
}
