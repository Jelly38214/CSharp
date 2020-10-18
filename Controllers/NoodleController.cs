using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace LanzhouBeefNoodles.Controllers
{
    public class NoodleController : Controller
    {
        public IList<String> Index()
        {
            return new List<String> {"牛肉面", "羊肉面", "鸡蛋面"};
        }
    }
}