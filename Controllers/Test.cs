using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LanzhouBeefNoodles.Controllers
{

    // 设置为public, http请求才能从外部访问控制器
    public class Test : Controller
    {

        // 同控制器一样，设置为public，http请求才能从外部访问这个Action
        public ActionResult Index()
        {
            return Content("Hello From test index");
        }

        public String About()
        {
            return "Hello From test About";
        }

        public ActionResult Contact() {
            return View();
        }
    }
}