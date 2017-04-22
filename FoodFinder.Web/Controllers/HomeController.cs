using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodFinder.Web.Model;
using Microsoft.AspNetCore.Mvc;
using FoodFinder.Web.Model;

namespace FoodFinder.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Venues()
        {
            return View();
        }

        public IActionResult Discussion()
        {
            var comment = new Comment
            {
                Title = "This is a great post",
                Details = "Whell the template give me so much inside"

            };

            var comments = new List<Comment>();
            comments.Add(comment);

            comments.Add(new Comment { Title = "Wow, this is awsom", CreatedBy = "Mr Friis"});


            return View(comments);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}