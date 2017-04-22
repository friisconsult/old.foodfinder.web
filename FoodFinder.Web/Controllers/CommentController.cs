using System;
using System.Linq;
using FoodFinder.Web.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodFinder.Web.Controllers
{
    [Route("Comment")]
    public class CommentController : Controller
    {
        private readonly TemplateContext _context;

        public CommentController(TemplateContext context)
        {
            _context = context;
        }


        [Route("")]
        public IActionResult Index()
        {
            var comments = _context.Comments.OrderByDescending(x => x.Created).Take(10).ToArray();

            return View(comments);
        }

        /// <summary>
        /// Return the number of pages of 10
        /// </summary>
        /// <returns></returns>
        [HttpGet,Route("pages")]
        public IActionResult NumberOfPages()
        {
            return Ok(_context.Comments.Count());
        }

        /// <summary>
        /// Show a specific comment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet,Route("{id}")]
        public IActionResult Comment([FromRoute] Guid id)
        {
            return View(_context.Comments.Find(id));
        }

        /// <summary>
        /// Show the create page
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet, Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost, Route("create")]
        public IActionResult Create([FromForm] Comment comment)
        {
            comment.CreatedBy = User.Identity.Name;

            _context.Comments.Add(comment);
            _context.SaveChanges();

            return RedirectToAction("Index", "comment", comment.Id);
        }


        public IActionResult Like()
        {
            throw new NotImplementedException();
        }
    }
}