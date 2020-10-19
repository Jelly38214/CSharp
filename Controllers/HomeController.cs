using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using LanzhouBeefNoodles.Models;
using LanzhouBeefNoodles.ViewModels;

// For more information on enabling MVC for empty projects, visting
namespace LanzhouBeefNoodles.Controllers
{
    public class HomeController : Controller
    {
        private INoodleRepository _noodleRepository;
        private IFeedbackRepository _feedbackRepository;

        public HomeController(INoodleRepository noodleRepository, IFeedbackRepository feedbackRepository)
        {
            _noodleRepository = noodleRepository;
            _feedbackRepository = feedbackRepository;
        }
        public IActionResult Index()
        {

            HomeViewModel viewModel = new HomeViewModel()
            {
                Feedbacks = _feedbackRepository.GetAllFeedbacks().ToList(),
                Noodles = _noodleRepository.GetAllNoodles().ToList()
            };
            return View(viewModel);
        }

        public String About()
        {
            return "Hello From About";
        }
    }
}