﻿using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        public IEnumerable<Restaurant> GetRestaurantsByName(string name);
        public Restaurant GetById(int id);
        public Restaurant Update(Restaurant restaurant);

        public Restaurant Add(Restaurant newRestaurant);

        public Restaurant Delete(int id);

        public int GetRestaurantsCount();
        public int Commit();
    }
}
