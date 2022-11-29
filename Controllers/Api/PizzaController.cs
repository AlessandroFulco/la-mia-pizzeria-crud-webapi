using la_mia_pizzeria_static.Models;
using la_mia_pizzeria_static.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Net.Http.Json;
using System.Xml;

namespace la_mia_pizzeria_static.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        public IDbPizzaRepository _pizzaRepository;
        public IDbCategoriesRepository _categoriesRepository;
        public IDbIngredientsRepository _ingredientsRepository;

        public PizzaController(IDbPizzaRepository pizzaRepository, IDbCategoriesRepository categoriesRepository, IDbIngredientsRepository ingredientsRepository)
        {
            

            _pizzaRepository = pizzaRepository;
            _categoriesRepository = categoriesRepository;
            _ingredientsRepository = ingredientsRepository;
        }

        public IActionResult Get()
        {
            
            List<Pizza> list = _pizzaRepository.All();
             
            return Ok(list);
        }

        public IActionResult Search(string? name)
        {
            List<Pizza> list = _pizzaRepository.SearchByName(name);

            return Ok(list);
        }
        
    }
}
