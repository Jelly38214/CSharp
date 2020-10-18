using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LanzhouBeefNoodles.Controllers
{
    [Route("admin/[controller]/[action]")]
    public class UserController : Controller
    {
        public IList<String> Index()
        {
            return new List<string> { "阿莱客斯" };
        }
    }
}