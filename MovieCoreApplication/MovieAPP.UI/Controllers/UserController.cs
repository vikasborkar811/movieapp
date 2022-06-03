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
    public class UserController : Controller
    {
        private IConfiguration _configuration;
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserModel userModel)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(userModel), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "User/Register";
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
        public async Task<IActionResult> ShowUserDetails()
        {
            //Fetch API,Axios Api, HTTPClient
            //HTTP Req/response

            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                // api url- http://localhost:5000/api/User/SelectUsers // (endpoint url)congigure this api url in upsetting file in MovieApp.UI
                // StringContent content = new StringContent(JsonConvert.SerializeObject(userInfo), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "User/SelectUser";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var userModel = JsonConvert.DeserializeObject<IEnumerable<UserModel>>(result);

                        return View(userModel);
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
        public async Task<IActionResult> Delete(int UserId)
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApiBaseUrl"] + "User/findUserById?UserId=" + UserId;
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        // var userModels = Newtonsoft.Json.JsonSerializer.Deserialize<List<UserModel>>(result);
                        var userModels = JsonConvert.DeserializeObject<UserModel>(result);
                        return View(userModels);
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries";
                    }
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UserModel userModel)
        {
            using (HttpClient client = new HttpClient())
            {

                string endpoint = _configuration["WebApiBaseUrl"] + "User/DeleteUser?UserId=" + userModel.UserId;
                using (var response = await client.DeleteAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "User-Deleted-Successfuly";
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
        public async Task<IActionResult> Edit(int userId)
        {
            string URL = _configuration["WebApiBaseUrl"] + "User/findUserById?UserId=" + userId;
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.GetAsync(URL))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        var userModel = JsonConvert.DeserializeObject<UserModel>(result);
                        return View(userModel);
                    }
                }
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Edit(UserModel userModel)
        {
            StringContent body = new StringContent(JsonConvert.SerializeObject(userModel), Encoding.UTF8, "application/json");
            string endpoint = _configuration["WebApiBaseUrl"] + "User/UpdateUser";
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
