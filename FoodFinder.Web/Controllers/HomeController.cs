using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
				Detail = "This is a great post",
				Created = DateTime.Now,
				CreatedBy = "Per Friis"
			};

		    var comments = new List<Comment>
		    {
		        comment,
		        new Comment {Detail = "Wow, this is awsom", Created = DateTime.Now.AddDays(-2), CreatedBy = "Hr Friis"}
		    };



		    return View(comments);
		}

		public IActionResult Error()
		{
			return View();
		}
	}
}
