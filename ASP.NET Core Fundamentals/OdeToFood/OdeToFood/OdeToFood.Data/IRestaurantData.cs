using OdeToFood.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantByName(string name); 
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>(){
                new Restaurant
                {
                    Id = 1,
                    Name = "Pizza",
                    Location = "Banani",
                    Cuisine = CuisineType.Italian
                },
                new Restaurant
                {
                    Id = 2,
                    Name = "Biriyani",
                    Location = "Badda",
                    Cuisine = CuisineType.Indian
                },
                new Restaurant
                {
                    Id = 3,
                    Name = "Bakery",
                    Location = "Dhanmondi",
                    Cuisine = CuisineType.None
                }
            };
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
