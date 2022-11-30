using la_mia_pizzeria_static.Models;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Data
{
    public class PizzeriaDbContext : DbContext
    {
        public static PizzeriaDbContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PizzeriaDbContext();
                }
                return _instance;
            }
        }
        public static PizzeriaDbContext _instance;
        public PizzeriaDbContext()
        {

        }

        public DbSet<Pizza> Pizze { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Message> Messages{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=la_mia_pizzeria;Integrated Security=True;Encrypt=false;");

        }
    }
}
