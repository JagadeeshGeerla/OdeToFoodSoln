using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config, IRestaurantData restaurantData)
        {
            Config = config;
            RestaurantData = restaurantData;
        }

        public IConfiguration Config { get; }
        public IRestaurantData RestaurantData { get; }

        public void OnGet()
        {
            Restaurants = RestaurantData.GetRestaurantsByName(SearchTerm);
            Message = Config["Message"];
        }
    }
}