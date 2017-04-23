using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FoodFinder.Web.Model;
using Newtonsoft.Json;

namespace FoodFinder.Web.Controllers
{
	[Route("Venue")]
	public class VenueController : Controller
	{
		private readonly TemplateContext _db;
		public VenueController(TemplateContext db)
		{
			_db = db;
		}

		public async Task<IActionResult> Index()
		{
		    //https://foodfinderapi.azurewebsites.net/api/venues

		    using (HttpClient foodfinderapi = new HttpClient())
		    {
		        var response = await foodfinderapi.GetAsync("https://foodfinderapi.azurewebsites.net/api/venues");

		        if (response.IsSuccessStatusCode)
		        {
		            var jsonString =  await response.Content.ReadAsStringAsync();
		            var venues = JsonConvert.DeserializeObject < Venue[]>(jsonString);
		            return View(venues);
		        }
		    }


			return View(_db.Venues.Take(10).ToList());
		}

		[Route("{id}")]
		public async Task<IActionResult> Venue(Guid id)
		{
		    using (HttpClient foodFinderAPI = new HttpClient())
		    {
		        var response = await foodFinderAPI.GetAsync($"https://foodfinderapi.azurewebsites.net/api/venues/{id.ToString()}");

		        if (!response.IsSuccessStatusCode) return NotFound();

		        var jsonString = await response.Content.ReadAsStringAsync();
		        var venue = JsonConvert.DeserializeObject<Venue>(jsonString);
		        return View(venue);
		    }
			return NotFound();
		}

		[HttpGet, Route("create")]
		public IActionResult Create()
		{
			Contract.Ensures(Contract.Result<IActionResult>() != null);

			List<SelectListItem> items = new List<SelectListItem>();
			items.Add(new SelectListItem { Text = "Choose...", Value = "Other" });
//			foreach (FoodType val in Enum.GetValues(typeof(FoodType)))
//			{
//				items.Add(new SelectListItem { Text = val.ToString(), Value = val.ToString() });
//			}

			//items.Add(new SelectListItem{Text = "fast"});
			ViewBag.FoodType = items;
			return View();
		}

		[HttpPost, Route("create")]
		public IActionResult CreateVenue(Venue venue)
		{
			_db.Venues.Add(venue);
			_db.SaveChanges();

			return RedirectToAction("Index", "venue");
		}
	}
}
