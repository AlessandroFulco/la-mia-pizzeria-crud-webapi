using la_mia_pizzeria_static.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;

namespace la_mia_pizzeria_static.Models.Repositories
{
    public class DbPizzaRepository : IDbPizzaRepository
    {
        //private PizzeriaDbContext db = PizzeriaDbContext.Instance;
        //private DbIngredientsRepository ingredientsRepository;
        private PizzeriaDbContext db;
        public IDbIngredientsRepository ingredientsRepository;
        public DbPizzaRepository(PizzeriaDbContext _db, IDbIngredientsRepository _ingredientsRepository)
        {
            db = _db;
            ingredientsRepository = _ingredientsRepository;
        }

        public List<Pizza> All()
        {
            return db.Pizze.Include(pizza => pizza.Category).Include(pizza => pizza.Ingredients).ToList();
        }

        public Pizza GetById(int id)
        {
            return db.Pizze.Where(p => p.Id == id).Include("Category").Include("Ingredients").FirstOrDefault();
        }

        public void Create(Pizza pizza, List<int> selectedIngredients)
        {
            pizza.Ingredients = new List<Ingredient>();

            foreach (int ingredientsId in selectedIngredients)
            {
                Ingredient ingredient = ingredientsRepository.GetById(ingredientsId);
                pizza.Ingredients.Add(ingredient);
            }

            db.Pizze.Add(pizza);
            db.SaveChanges();
        }

        public void Update(Pizza pizza, Pizza formData, List<int> selectedIngredients)
        {
            if (selectedIngredients == null)
                selectedIngredients = new List<int>();


            pizza.Name = formData.Name;
            pizza.Description = formData.Description;
            pizza.Photo = formData.Photo;
            pizza.Price = formData.Price;
            pizza.CategoryId = formData.CategoryId;

            pizza.Ingredients.Clear();

            foreach (int ingredientsId in selectedIngredients)
            {
                Ingredient ingredient = ingredientsRepository.GetById(ingredientsId);
                pizza.Ingredients.Add(ingredient);
            }

            db.SaveChanges();
        }

        public void Delete(Pizza pizza)
        {
            db.Pizze.Remove(pizza);
            db.SaveChanges();
        }

        public void Update(Pizza formData, List<int> selectedIngredients)
        {
            throw new NotImplementedException();
        }

        public List<Pizza> SearchByName(string? name)
        {
            IQueryable<Pizza> query = db.Pizze.Include("Category").Include("Ingredients");

            if (name == null)
                return query.ToList();

            return query.Where( pizza => pizza.Name.ToLower().Contains(name.ToLower())).ToList();
        }
    }
}
