﻿using la_mia_pizzeria_static.Data;

namespace la_mia_pizzeria_static.Models.Repositories
{
    public class DbIngredientsRepository : IDbIngredientsRepository
    {
        private PizzeriaDbContext db = PizzeriaDbContext.Instance;


        



        public Ingredient GetById(int ingredientId)
        {
            return db.Ingredients.Where(c => c.Id == ingredientId).FirstOrDefault();
        }

        public List<Ingredient> All()
        {
            return db.Ingredients.ToList();
        }
    }
}
