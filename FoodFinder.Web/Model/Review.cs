using System;

namespace FoodFinder.Web.Model
{
    public class Review
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }

        public string Owner { get; set; }

        public int Stars { get; set; }
        public string Author { get; set; }
    }
}