using System;

namespace FoodFinder.Web.Model
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public string CreatedBy { get; set; }
        public bool Deleted { get; set; } = false;
        public string Owner { get; set; }

        public int Likes { get; set; } = 0;

    }
}