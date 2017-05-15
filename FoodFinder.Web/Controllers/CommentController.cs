using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using FoodFinder.Web.Authentication;
using FoodFinder.Web.Model;
using Microsoft.AspNetCore.Authorization;

namespace FoodFinder.Web.Controllers
{
	[Route("Comment")]
	public class CommentController : Controller
	{
		private readonly TemplateContext _db;

		public CommentController(TemplateContext db)
		{
			_db = db;
		}

		/// <summary>
		/// List the 10 latest comments
		/// </summary>
		/// <returns>The index. view</returns>
		[Route("")]
		public IActionResult Index()
		{
			var comments = _db.Comments.OrderByDescending(x => x.Created).Take(10).ToArray();

			return View(comments);
		}

		/// <summary>
		/// Show single comment
		/// </summary>
		/// <returns>The comment.</returns>
		/// <param name="id">Identifier.</param>
		[Route("{id}")]
		public IActionResult Comment(Guid id)
		{
			var comment = _db.Comments.FirstOrDefault(x => x.Id == id);
			return View(comment);
		}


		/// <summary>
		/// Show the create comment page
		/// </summary>
		/// <returns>The create.</returns>
		[Authorize]
		[HttpGet, Route("create")]
		public IActionResult Create()
		{
			return View();
		}

		/// <summary>
		/// Create when user post a comment
		/// </summary>
		/// <returns>The create.</returns>
		/// <param name="comment">Comment.</param>
		[HttpPost, Route("create")]
		public IActionResult Create(Comment comment)
		{
			comment.CreatedBy = User.GetNickName();
			comment.Owner = User.GetUserId();
			comment.Created = DateTime.Now;

			_db.Comments.Add(comment);
			_db.SaveChanges();

			return RedirectToAction($"Index", $"comment", comment.Id);
		}
	}
}
