using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MovieApp.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.UI.Controllers
{
    public class MovieController : Controller
    {
        private IConfiguration _configuration;
        public MovieController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(MovieModel movieModel)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(movieModel), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Movie/AddMovie";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer","token");
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Register successfully!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries!";
                    }
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ShowMovieDetails()
        {
            //Fetch API,Axios Api, HTTPClient
            //HTTP Req/response

            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                // api url- http://localhost:5000/api/User/SelectUsers // (endpoint url)congigure this api url in upsetting file in MovieApp.UI
                // StringContent content = new StringContent(JsonConvert.SerializeObject(userInfo), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Movie/SelectMovie";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var movieModel = JsonConvert.DeserializeObject<IEnumerable<MovieModel>>(result);

                        return View(movieModel);
                    }

                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong user entries!";
                    }
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DeleteMovieById(int movieId)
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApiBaseUrl"] + "Movie/findMovieById?MovieId=" + movieId;
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        // var userModels = Newtonsoft.Json.JsonSerializer.Deserialize<List<UserModel>>(result);
                        var movieModels = JsonConvert.DeserializeObject<MovieModel>(result);
                        return View(movieModels);
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries";
                    }
                }

                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMovieById(MovieModel movieModel)
        {
            using (HttpClient client = new HttpClient())
            {

                string endpoint = _configuration["WebApiBaseUrl"] + "Movie/DeleteMovie?MovieId=" + movieModel.MovieId;
                using (var response = await client.DeleteAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Movie-Deleted-Successfuly";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Invalid input ";
                    }
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditMovieById(int movieId)
        {
            string URL = _configuration["WebApiBaseUrl"] + "Movie/findMovieById?MovieId=" + movieId;
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.GetAsync(URL))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        var movieModel = JsonConvert.DeserializeObject<MovieModel>(result);
                        return View(movieModel);
                    }
                }
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> EditMovieById(MovieModel movieModel)
        {
            StringContent body = new StringContent(JsonConvert.SerializeObject(movieModel), Encoding.UTF8, "application/json");
            string endpoint = _configuration["WebApiBaseUrl"] + "Movie/UpdateMovie";
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.PutAsync(endpoint, body))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Movie Updated Successfully..!!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Soory.. Unable To Edit movie..!!";
                    }
                }
            }
            return View();
        }
    }
}
