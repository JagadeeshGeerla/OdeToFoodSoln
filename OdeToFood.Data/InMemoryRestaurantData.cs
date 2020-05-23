using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        public List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant(){Id=1, Name="Mexico Resto", Location="Mexico", Cuisine=CuisineType.Mexican},
                new Restaurant(){Id=2, Name="Italian Resto", Location="Italy", Cuisine=CuisineType.Italian},
                new Restaurant(){Id=3, Name="Indian Resto", Location="Indian", Cuisine=CuisineType.Indian},
            };
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant GetById(int id) => restaurants.SingleOrDefault(r => r.Id == id);

        public IEnumerable<Restaurant> GetRestaurantsByName(string name=null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id)+1;

            return newRestaurant;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if(restaurant!=null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }

            return restaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);

            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }

            return restaurant;
        }
    }
}
