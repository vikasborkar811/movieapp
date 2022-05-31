using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MovieApp.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.UI.Controllers
{
    public class TheatreController : Controller
    {
        private IConfiguration _configuration;
        public TheatreController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddTheatre()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTheatre(TheatreModel theatreModel)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(theatreModel), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Theatre/AddTheatre";
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
        public async Task<IActionResult> ShowTheatreDetails()
        {
            //Fetch API,Axios Api, HTTPClient
            //HTTP Req/response

            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
               
                string endPoint = _configuration["WebApiBaseUrl"] + "Theatre/SelectTheatre";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var theatreModels = JsonConvert.DeserializeObject<IEnumerable<TheatreModel>>(result);

                        return View(theatreModels);
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
        public async Task<IActionResult> DeleteTheatreById(int theatreId)
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApiBaseUrl"] + "Theatre/findTheatreById?TheatreId=" + theatreId;
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        // var userModels = Newtonsoft.Json.JsonSerializer.Deserialize<List<UserModel>>(result);
                        var theatreModel = JsonConvert.DeserializeObject<TheatreModel>(result);
                        return View(theatreModel);
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
        public async Task<IActionResult> DeleteTheatreById(TheatreModel theatreModel)
        {
            using (HttpClient client = new HttpClient())
            {

                string endpoint = _configuration["WebApiBaseUrl"] + "Theatre/DeleteTheatre?theatreId=" + theatreModel.TheatreId;
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
        public async Task<IActionResult> EditTheatreById(int theatreId)
        {
            string URL = _configuration["WebApiBaseUrl"] + "Theatre/findTheatreById?TheatreId=" + theatreId;
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.GetAsync(URL))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        //var theatreModel = JsonConvert.DeserializeObject<TheatreModel>(result); // getting only single record of usermodel

                        //return View(theatreModel);
                        return View(JsonConvert.DeserializeObject<TheatreModel>(result));
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong theatre entries!";
                    }
                }
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> EditTheatreById(TheatreModel theatreModel)
        {
            StringContent body = new StringContent(JsonConvert.SerializeObject(theatreModel), Encoding.UTF8, "application/json");
            string endpoint = _configuration["WebApiBaseUrl"] + "Theatre/UpdateTheatre";
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.PutAsync(endpoint, body))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Theatre Updated Successfully..!!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Sorry.. Unable To Update..!!";
                    }
                }
            }
            return View();
        }
    }
}
