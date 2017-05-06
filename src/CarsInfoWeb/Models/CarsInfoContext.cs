using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarsInfoWeb.Models
{
    public class CarsInfoContext : IdentityDbContext<ApplicationUser>
    {

        public CarsInfoContext(DbContextOptions<CarsInfoContext> options)
            : base(options)
        { }

        public DbSet<Car> Cars { get; set; }
        
    }
}
