using C_Scherp_Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace C_Scherp_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly CScherpContext _context;

        public IngredientsController(CScherpContext context)
        {
            _context = context;
        }


        /// <summary>
        /// 🚀 Secure endpoint - Requires authentication.
        /// </summary>
        /// <response code="401">Unauthorized - You must provide a valid token.</response>
        // GET: api/Ingredient
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Ingredient>>> GetIngredients()
        {
            var ingredients = await _context.Ingredients.ToListAsync();

            if (!ingredients.Any())
            {
                return NotFound("No ingredients found.");
            }

            return Ok(ingredients);
        }


        /// <summary>
        /// 🚀 Secure endpoint - Requires authentication.
        /// </summary>
        /// <response code="401">Unauthorized - You must provide a valid token.</response>
        // GET: api/Ingredients/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Ingredient>> GetIngredient(int id)
        {
            var ingredient = await _context.Ingredients.FindAsync(id);

            if (ingredient == null)
            {
                return NotFound();
            }

            return ingredient;
        }

        /// <summary>
        /// 🚀 Secure endpoint - Requires authentication.
        /// </summary>
        /// <response code="401">Unauthorized - You must provide a valid token.</response>
        // PUT: api/Ingredients/5
        [HttpPut("{id}")]
        [Authorize]

        public async Task<IActionResult> PutIngredient(int id, Ingredient ingredient)
        {
            if (id != ingredient.Id)
            {
                return BadRequest();
            }

            _context.Entry(ingredient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// 🚀 Secure endpoint - Requires authentication.
        /// </summary>
        /// <response code="401">Unauthorized - You must provide a valid token.</response>
        // POST: api/Ingredients
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Ingredient>> PostIngredient(Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIngredient", new { id = ingredient.Id }, ingredient);
        }

        /// <summary>
        /// 🚀 Secure endpoint - Requires authentication.
        /// </summary>
        /// <response code="401">Unauthorized - You must provide a valid token.</response>
        // DELETE: api/Ingredients/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteIngredient(int id)
        {
            var ingredient = await _context.Ingredients.FindAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }

            _context.Ingredients.Remove(ingredient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IngredientExists(int id)
        {
            return _context.Ingredients.Any(e => e.Id == id);
        }
    }
}
