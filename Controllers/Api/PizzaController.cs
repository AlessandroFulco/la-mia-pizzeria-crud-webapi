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
        IDbPizzaRepository _pizzaRepository;

        public PizzaController(IDbPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        public IActionResult Get()
        {
            
            List<Pizza> list = _pizzaRepository.All();
             
            return Ok(list);
        }

        public IActionResult SearchByName(string? name)
        {
            List<Pizza> list = _pizzaRepository.SearchByName(name);

            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            Pizza pizza = _pizzaRepository.GetById(id);
            return Ok(pizza);
        }

        //public IActionResult getCategories()
        //{
        //    List<Category> list = _categoriesRepository.All();
        //    return Ok(list);
        //}
        
    }
}
