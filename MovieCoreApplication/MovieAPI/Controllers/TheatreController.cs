using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Entity;
using MovieApp.Business.Service;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheatreController : ControllerBase
    {
        TheatreService _theatreService;

        public TheatreController(TheatreService theatreService)
        {
            _theatreService = theatreService;
        }

        [HttpGet("SelectTheatre")]
        public IActionResult SelectTheatre()
        {
            return Ok(_theatreService.SelectTheatre());
        }

        [HttpPost("AddThetre")]
        public IActionResult AddThetre(TheatreModel theatreModel)
        {
            return Ok(_theatreService.AddThetre(theatreModel));
        }

        [HttpGet("findTheatreById")]
        public IActionResult findTheatreById(int UserId)
        {
            return Ok(_theatreService.findTheatreById(UserId));
        }

        [HttpDelete("DeleteTheatre")]
        public IActionResult DeleteTheatre(int id)
        {
            return Ok(_theatreService.DeleteTheatre(id));
        }


        [HttpPut("UpdateTheatre")]
        public IActionResult UpdateTheatre(TheatreModel theatreModel)
        {
            return Ok(_theatreService.UpdateTheatre(theatreModel));

        }
    }
}
