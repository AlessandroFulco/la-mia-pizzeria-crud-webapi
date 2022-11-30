using la_mia_pizzeria_static.Data;

namespace la_mia_pizzeria_static.Models.Repositories
{
    public class DbCategoriesRepository : IDbCategoriesRepository
    {
        PizzeriaDbContext db;

        public DbCategoriesRepository(PizzeriaDbContext _db)
        {
            db = _db;    
        }

        public List<Category>? All()
        {
            return db.Categories.ToList();
        }
    }
}
