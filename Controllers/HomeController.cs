using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visting
namespace LanzhouBeefNoodles.Controllers
{
    public class HomeController : Controller
    {
        public String Index()
        {
            return "Hello From Home";
        }

        public String About()
        {
            return "Hello From About";
        }
    }
}