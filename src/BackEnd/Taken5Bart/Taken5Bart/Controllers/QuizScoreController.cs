using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Taken5Bart.Controllers
{
    public class QuizScoreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}