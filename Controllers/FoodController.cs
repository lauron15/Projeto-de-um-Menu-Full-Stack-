using Foods.Model;
using Foods.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Importar para usar ToListAsync

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
            var listarFood = await _context.foods.ToListAsync(); // Usar ToListAsync
            return Ok(listarFood); // Retornar OK
        }
     

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<Food> PostFood(Food foods)
        {
            if (foods == null)
            {
                return BadRequest("Food cannot be null."); // Verificar se foods é nulo
            }
            _context.foods.Add(foods);
             _context.SaveChanges();
            return CreatedAtAction("GetFood", new { id = foods.id }, foods);
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> PutFood(int id, Food foods)
        {
            var foodAntiga = await _context.foods.FirstOrDefaultAsync(f => f.id == id); // Buscar pelo id
            if (foodAntiga == null)
            {
                return NotFound();
            }

           

            _context.foods.Update(foodAntiga); // Atualizar a entidade
            await _context.SaveChangesAsync();
            return NoContent();
       
        }

        [HttpDelete("{id}")]
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
        }

    }

}



    
