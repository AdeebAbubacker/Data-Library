using DataLibrary_Api.Controllers.Models;
using Microsoft.AspNetCore.Mvc;


namespace DataLibrary_Api.Controllers
{
    [Route("api/Cras")]
    [ApiController]
    public class CarController : ControllerBase
    {

        //httpverbs
        [HttpGet]
        public IEnumerable<Cars> GetLibraries()
        {
            return new List<Cars>
            {
                new Cars{Id=1,Name ="Ferrari"},
                new Cars{Id=2,Name ="Lamborgini"},
                new Cars{Id=3,Name ="Bugati"},
            };
        }
    }
}
