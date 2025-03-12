using DataLibrary_Api.Data;
using DataLibrary_Api.Controllers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLibrary_Api.Controllers
{
    [Route("api/gymequipments")]
    [ApiController]
    public class GymController : ControllerBase
    {
        private readonly GymDbContext _context;

        public GymController(GymDbContext context)
        {
            _context = context;
        }

        // ✅ GET All Cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GymEquipments>>> GetCars()
        {
            return await _context.Gym.ToListAsync();
        }

    }
}
