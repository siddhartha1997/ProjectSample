using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HotelManagementClient.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelManagementClient.Controllers
{
    public class BoarderController : Controller
    {
        Uri baseaddress = new Uri("https://localhost:44391/api");
        HttpClient client;
        public BoarderController()
        {
            client = new HttpClient();
            client.BaseAddress = baseaddress;
        }
        public IActionResult Index()
        {
            List<Boarder> ls = new List<Boarder>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Boarder").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                ls = JsonConvert.DeserializeObject<List<Boarder>>(data);
            }
            return View(ls);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Boarder obj)
        {
            string data = JsonConvert.SerializeObject(obj);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/Boarder", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(string id)
        {
            Boarder ls = new Boarder();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Boarder/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                ls = JsonConvert.DeserializeObject<Boarder>(data);
            }
            return View(ls);
        }
        [HttpPost]
        public IActionResult Edit(Boarder obj)
        {
            string data = JsonConvert.SerializeObject(obj);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/Boarder/" + obj.Email, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(string id)
        {
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/Boarder/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
    }
}
