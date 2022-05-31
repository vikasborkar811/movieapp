using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;
using MovieApp.Entity;

namespace MovieApp.UI.Controllers
{
    public class MovieShowTimeController : Controller
    {
        public IActionResult Index1()
        {
            return View();
        }

        IConfiguration _configuration;
        public MovieShowTimeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "MovieShowTime/ShowMovieTimeList";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var movieShowTimes = JsonConvert.DeserializeObject<List<MovieApp.Entity.MovieShowTime>>(result);
                        return View(movieShowTimes);
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "No Data Found!";
                    }
                }
            }
            //StatusCode : 200,201,404,500
            return View();
        }

        public IActionResult InsertMovieShowTime()
        {
            //var movieshowdata=apicontro.action(); movieid,moviename

            List<SelectListItem> selectListItems = new List<SelectListItem>();
            SelectListItem selectListItem = new SelectListItem();
            selectListItem.Text = "Select";
            selectListItem.Value = "0";
            selectListItems.Add(selectListItem);

            selectListItem = new SelectListItem();
            selectListItem.Text = "RRR";
            selectListItem.Value = "1";
            selectListItems.Add(selectListItem);

            selectListItem = new SelectListItem();
            selectListItem.Text = "Beast";
            selectListItem.Value = "2";
            selectListItems.Add(selectListItem);

            ViewBag.movieShowList = selectListItems;
            TempData["movieShowList"] = selectListItems;

            List<SelectListItem> theatreListItmes = new List<SelectListItem>();
            selectListItem = new SelectListItem();
            selectListItem.Text = "Select";
            selectListItem.Value = "0";
            theatreListItmes.Add(selectListItem);

            selectListItem = new SelectListItem();
            selectListItem.Text = "PVR";
            selectListItem.Value = "1";
            theatreListItmes.Add(selectListItem);

            selectListItem = new SelectListItem();
            selectListItem.Text = "INOX";
            selectListItem.Value = "2";
            theatreListItmes.Add(selectListItem);

            ViewBag.theatreList = theatreListItmes;
            TempData["theatreList"] = theatreListItmes;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InsertMovieShowTime(MovieApp.Entity.MovieShowTime movieShowTime)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(movieShowTime), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "MovieShowTime/InsertMovieShowTime";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Inserted!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries!";
                    }
                    
                }
            }
            //StatusCode : 200,201,404,500
            return RedirectToAction("Index", "MovieShowTime");
        }

        [HttpGet]
        public async Task<IActionResult> EditMovieshowTime(int movieshowtimeId)
        {
            string URL = _configuration["WebApiBaseUrl"] + "MovieShowTime/findMovieShowTimeById?showid=" + movieshowtimeId;
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.GetAsync(URL))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        var movieshowtimeModel = JsonConvert.DeserializeObject<MovieShowTime>(result);
                        return View(movieshowtimeModel);
                    }
                }
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> EditMovieshowTime(MovieShowTime movieShowTime)
        {
            StringContent body = new StringContent(JsonConvert.SerializeObject(movieShowTime), Encoding.UTF8, "application/json");
            string endpoint = _configuration["WebApiBaseUrl"] + "MovieShowTime/UpdateMovieShowTime";
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.PutAsync(endpoint, body))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "User Updated Successfully..!!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Soory.. Unable To Register..!!";
                    }
                }
            }
            return View();
        }
    }
}
