using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly ILogger<ListModel> logger;

        [TempData]
        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config, IRestaurantData restaurantData, ILogger<ListModel> logger)
        {
            Config = config;
            RestaurantData = restaurantData;
            this.logger = logger;
        }

        public IConfiguration Config { get; }
        public IRestaurantData RestaurantData { get; }

        public void OnGet()
        {
            logger.LogError("Hello from List!");
            Restaurants = RestaurantData.GetRestaurantsByName(SearchTerm);
            //Message = Config["Message"];           
        }
    }
}