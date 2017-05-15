using System;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FoodFinder.Web.Authentication;
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
            using (var foodFinderApi = new HttpClient())
		    {
		        foodFinderApi.DefaultRequestHeaders.Add("FC-APPLICATION-KEY", "Agrajag");
		        var response = await foodFinderApi.GetAsync("https://foodfinderapi.azurewebsites.net/api/venues");

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
		    using (var foodFinderApi = new HttpClient())
		    {
		        foodFinderApi.DefaultRequestHeaders.Add("FC-APPLICATION-KEY", "Agrajag");
		        var response = await foodFinderApi.GetAsync($"https://foodfinderapi.azurewebsites.net/api/venues/{id.ToString()}");

		        if (!response.IsSuccessStatusCode) return NotFound();

		        var jsonString = await response.Content.ReadAsStringAsync();
		        var venue = JsonConvert.DeserializeObject<Venue>(jsonString);

		        var menuResponse =
		            await foodFinderApi.GetAsync($"https://foodfinderapi.azurewebsites.net/api/menuitem/menu/{venue.Id.ToString()}");

		        if (menuResponse.IsSuccessStatusCode)
		        {
		            var memuItemsJson = await menuResponse.Content.ReadAsStringAsync();
		            venue.MenuItems = JsonConvert.DeserializeObject<MenuItem[]>(memuItemsJson);

		        }

		        var reviewresponse = await foodFinderApi.GetAsync(
		            $"https://foodfinderapi.azurewebsites.net/api/reviews/venue/{venue.Id.ToString()}");

		        if (!reviewresponse.IsSuccessStatusCode) return View(venue);

		        var reviewsJson = await reviewresponse.Content.ReadAsStringAsync();
		        venue.Reviews = JsonConvert.DeserializeObject<Review[]>(reviewsJson);

		        return View(venue);
		    }
			return NotFound();
		}

		[HttpGet, Route("create")]
		public IActionResult Create()
		{
			Contract.Ensures(Contract.Result<IActionResult>() != null);

			//ViewBag.FoodType = items;
			return View();
		}

		[HttpPost, Route("create")]
		public async Task<IActionResult> CreateVenue(Venue venue)
		{
		    using (var foodFinderApi = new HttpClient())
		    {
			    venue.Owner = User.GetUserId();
		        var venues = new Venue[] {venue};


		        var jsonString = JsonConvert.SerializeObject(venues);
		        var stringContext = new StringContent(jsonString,Encoding.UTF8,"application/json");


                foodFinderApi.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
		        foodFinderApi.DefaultRequestHeaders.Add("FC-APPLICATION-KEY", "Agrajag");
		        var response = await foodFinderApi.PostAsync("https://foodfinderapi.azurewebsites.net/api/venues", stringContext);

		        if (response.IsSuccessStatusCode)
		            return RedirectToAction("Index");


		    }

		    return Ok();
        }
	}
}
