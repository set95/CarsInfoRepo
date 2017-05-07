using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CarsInfoWeb.Models
{
    public class BloggingContext : DbContext
    {
        public BloggingContext(DbContextOptions<BloggingContext> options)
            : base(options)
        { }

        public DbSet<Cars> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }

    public class Cars
    {
        public int CarId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }

        public List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Cars Cars { get; set; }
    }
}
