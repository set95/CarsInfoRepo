using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CarsInfoWeb.Models
{
    public class CarsInfoContext : DbContext
    {

        public CarsInfoContext(DbContextOptions<CarsInfoContext> options)
            : base(options)
        { }

        public DbSet<Car> Cars { get; set; }
    }
}
