using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsInfoWeb.Models;

namespace CarsInfoWeb.ViewModel
{
    public class HomeViewModel
    {
        public SearchCarsViewModel modelSearch { get; set; }
        public IEnumerable<Car> modelCar { get; set; }
    }
}
