using System;

namespace FoodFinder.Web.Model
{
    public class MenuItem
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Detail { get; set; }
        public bool Deleted { get; set; }

        public MenuItemType Type { get; set; }
        public double Price { get; set; }

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