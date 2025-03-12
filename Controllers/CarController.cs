using DataLibrary_Api.Data;
using DataLibrary_Api.Controllers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLibrary_Api.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CarDbContext _context;

        public CarController(CarDbContext context)
        {
            _context = context;
        }

        // ✅ GET All Cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cars>>> GetCars()
        {
            return await _context.Cars.ToListAsync();
        }

        // ✅ GET Car by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Cars>> GetCarById(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return car;
        }

        // ✅ POST API to Add a New Car
        [HttpPost]
        public async Task<ActionResult<Cars>> PostCar([FromBody] Cars car)
        {
            if (car == null)
            {
                return BadRequest("Car data is required.");
            }

            _context.Cars.Add(car);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCarById), new { id = car.Id }, car);
        }

        // ✅ PUT (Update) a Car
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, [FromBody] Cars car)
        {
            if (id != car.Id)
            {
                return BadRequest("Car ID mismatch.");
            }

            var existingCar = await _context.Cars.FindAsync(id);
            if (existingCar == null)
            {
                return NotFound();
            }

            existingCar.Name = car.Name;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, "Error updating the car.");
            }

            return NoContent();
        }

        // ✅ DELETE a Car
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

