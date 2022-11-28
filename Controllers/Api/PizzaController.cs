using la_mia_pizzeria_static.Models;
using la_mia_pizzeria_static.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace la_mia_pizzeria_static.Controllers.Api
{
    [Route("api/[PizzaController]/[all]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        public DbPizzaRepository pizzaRepository;
        public List<Pizza> Pizze;

        public PizzaController()
        {
            pizzaRepository = new DbPizzaRepository();
        }

        public void Index()
        {

        }
        
    }
}
