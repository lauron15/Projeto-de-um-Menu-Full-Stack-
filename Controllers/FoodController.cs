using Foods.Model;
using Foods.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Foods.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly AppDatabase _context;
        public FoodController(AppDatabase context)
        {    
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Food>>> listarFoods()
        {
            var listarFood = _context.foods.ToList();
            return listarFood;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult>PostFood(Food foods)
        {
           _context.foods.Add(foods);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetFood", new { id = foods.id }, foods);
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult>PutFood(Food foods)
        {
            var foodAntiga = _context.foods.FirstOrDefault();
            if (foodAntiga == null) {
                return NotFound();
                
            }

            _context.foods.Remove(foodAntiga);
            await _context.SaveChangesAsync();
            return NoContent();
        }

     /*   [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteFood(long id)
        {
            var comida = await _context.foods.FindAsync(id);
            if (comida == null)
            {
                return NotFound();
            }

            _context.foods.Remove(comida);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ComidasExistente(int id)
        {
            return _context.foods.Any(e => e.id == id);
        }*/

    }

}
