using DataLibrary_Api.Controllers.Models;
using Microsoft.AspNetCore.Mvc;


namespace DataLibrary_Api.Controllers
{
    [Route("api/Library")]
    [ApiController]
    public class LibraryController : ControllerBase
    {

        // //httpverbs
        // [HttpGet]
        // public IEnumerable<Library>GetLibraries()
        // {
        //     return new List<Library>
        //     {
        //         new Library{Id=1,Name =" Wings of fire"},
        //         new Library{Id=2,Name ="Aaadujevitham"},
        //         new Library{Id=3,Name ="Ennu ninde moideen"},
        //     };
        // }
        [HttpGet("{id}")]
        public IActionResult GetLibraryById(int id)
        {
            var libraries = new List<Library>
    {
        new Library{Id=1, Name ="Wings of Fire"},
        new Library{Id=2, Name ="Aadujeevitham"},
        new Library{Id=3, Name ="Ennu Ninde Moideen"}
    };

            var library = libraries.FirstOrDefault(l => l.Id == id);

            if (library == null)
            {
                return NotFound("Library not found");
            }

            return Ok(library);
        }

    }
}
