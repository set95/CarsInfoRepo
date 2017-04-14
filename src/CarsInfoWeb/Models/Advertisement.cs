using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsInfoWeb.Models
{
    public class Advertisement
    {
        private int AdId { get; set; }
        private int UserId { get; set; }
        private Vehicle AdVehicle { get; set; }

        public Advertisement(int adId, int userId, Vehicle adVehicle)
        {
            this.AdId = adId;
            this.UserId = userId;
            this.AdVehicle = adVehicle;
        }

    }
}
