﻿using System.Collections.Generic;

namespace FoodFinder.Web.Model
{
    public class Venue : EntityBase
    {
        public FoodType Type { get; set; } = FoodType.Other;
        public string LogoImaageUrl { get; set; }
        public string Street { get; set; }
        public string PostacCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string PHone { get; set; }

        public double Latitude { get; set; } = 0;
        public double Longitude { get; set; } = 0;

        public double PriceLevel { get; set; } = 50;

        public  ICollection<MenuItem> MenuItems { get; set; }
        public  ICollection<Review> Reviews { get; set; }
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