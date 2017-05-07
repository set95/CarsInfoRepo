using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CarsInfoWeb.Models
{

    public class Cars
    {
        public int CarId { get; set; }
        public string Style { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Engine { get; set; }
        public string Transmission { get; set; }

    }

   
}
