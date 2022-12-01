using la_mia_pizzeria_static.Data;
using Microsoft.AspNetCore.Mvc;
using la_mia_pizzeria_static.Models;

namespace la_mia_pizzeria_static.Controllers.Api
{
    [Route("api/[controller][action]")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        public PizzeriaDbContext db;
        public CommentController(PizzeriaDbContext _db)
        {
            db = _db;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Comment comment)
        {
            try
            {
                db.Comments.Add(comment);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
            return Ok(comment);
        }
    }
}
