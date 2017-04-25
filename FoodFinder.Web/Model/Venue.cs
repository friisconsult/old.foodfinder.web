namespace FoodFinder.Web.Model
{
    public class Venue:EntityBase
    {
        public FoodType Type { get; set; }

        public double PriceLevel { get; set; }

        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
   }

    public enum FoodType
    {
     Other,
     FastFood,
     Indian,
     Mexican,
     French,
     MiddelEast,
     African,
     European,
     American,
     Vegetarian,
     LocalFood
    }
}