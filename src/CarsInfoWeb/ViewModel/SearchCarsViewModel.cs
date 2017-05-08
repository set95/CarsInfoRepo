using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using CarsInfoWeb.Models;
using Microsoft.EntityFrameworkCore.Query.ExpressionTranslators.Internal;

namespace CarsInfoWeb.ViewModel
{
    public class SearchCarsViewModel
    {
 
        public string Make { get; set; }

    
        public string Model { get; set; }

        [Range(0,int.MaxValue),Display(Name = "Min Price(Euro)")]
        public decimal? MinPrice { get; set; }

        [Range(0, int.MaxValue), Display(Name = "Max Price(Euro)")]
        public decimal? MaxPrice { get; set; }


        [Range(0, 2020, ErrorMessage = "Invalid Year")]
        public int? MinYear { get; set; }

        [Range(0, 2020, ErrorMessage = "Please enter valid Year"), Display(Name = "Max Year")]
        public int? MaxYear { get; set; }

        [Range(0,2000000),Display(Name = "Mileage(km)")]
        public int? Mileage { get; set; }

        public string Color { get; set; }
        public string Fuel { get; set; }
        public string Type { get; set; }
    }
}
