using System;

namespace FoodFinder.Web.Model
{
    public class Review:EntityBase
    {

        public int Stars { get; set; }
        public string Author { get; set; }

        public Guid VenueId { get; set; }
        public Venue Venue { get; set; }
    }
}