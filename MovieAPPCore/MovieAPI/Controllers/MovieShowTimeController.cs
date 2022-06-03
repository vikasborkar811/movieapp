using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Business.Service;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieShowTimeController : ControllerBase
    {
        MovieShowTimeService _MovieShowTimeService;
        public MovieShowTimeController(MovieShowTimeService movieShowTime)
        {
            _MovieShowTimeService = movieShowTime;
        }
        [HttpGet("ShowMovieTimeList")]
        public IActionResult ShowMovieTimeList()
        {
            return Ok(_MovieShowTimeService.ShowMovieTimeList());
        }
        [HttpPost("InsertMovieShowTime")]
        public IActionResult InsertMovieShowTime(MovieApp.Entity.MovieShowTime movieShowTime)
        {
            return Ok(_MovieShowTimeService.InsertMovieShowTime(movieShowTime));
        }

        [HttpPut("UpdateMovieShowTime")]
        public IActionResult UpdateMovieShowTime(MovieApp.Entity.MovieShowTime movieShowTime)
        {
            return Ok(_MovieShowTimeService.UpdateMovieShowTime(movieShowTime));
        }

        [HttpGet("EditMovieshowTime")]
        public IActionResult findMovieShowTimeById(int movieShowTimeId)
        {
            return Ok(_MovieShowTimeService.findMovieShowTimeById(movieShowTimeId));
        }

        [HttpDelete("DeleteMovieShowTime")]
        public IActionResult DeleteMovieShowTime(int movieShowTimeId)
        {
            return Ok(_MovieShowTimeService.DeleteMovieShowTime(movieShowTimeId));
        }
    }
}
