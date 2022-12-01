using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace la_mia_pizzeria_static.Data
{
    public class PizzeriaDbContext : IdentityDbContext<IdentityUser>
    {
        //public static PizzeriaDbContext Instance
        //{
        //    get
        //    {
        //        if (_instance == null)
        //        {
        //            _instance = new PizzeriaDbContext();
        //        }
        //        return _instance;
        //    }
        //}
        public static PizzeriaDbContext _instance;

        public PizzeriaDbContext(DbContextOptions<PizzeriaDbContext> options)
        : base(options)
        {
        }

        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Pizza> Pizze { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Message> Messages{ get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=la_mia_pizzeria;Integrated Security=True;Encrypt=false;");

        //}
    }
}
