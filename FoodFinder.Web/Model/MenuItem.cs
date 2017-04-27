using System;
using Newtonsoft.Json;

namespace FoodFinder.Web.Model
{
    public class MenuItem : EntityBase
    {
        public MenuItemType Type { get; set; }
        public double Price { get; set; }

        public Guid VenueId { get; set; }
    }





    public enum MenuItemType
    {
        Starter,
        Main,
        SideDish,
        Dessert,
        SoftDrink,
        AlcoholicDrink
    }
}