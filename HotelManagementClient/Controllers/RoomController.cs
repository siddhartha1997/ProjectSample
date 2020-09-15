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
    public class RoomController : Controller
    {
        Uri baseaddress = new Uri("https://localhost:44391/api");
        HttpClient client;
        public RoomController()
        {
            client = new HttpClient();
            client.BaseAddress = baseaddress;
        }
        public IActionResult Index()
        {
            List<Room> ls = new List<Room>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Room").Result;
            if(response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                ls = JsonConvert.DeserializeObject<List<Room>>(data);
            }
            return View(ls);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Room obj)
        {
            string data = JsonConvert.SerializeObject(obj);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/Room", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int id)
        {
            Room ls = new Room();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Room/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                ls = JsonConvert.DeserializeObject<Room>(data);
            }
            return View(ls);
        }
        [HttpPost]
        public IActionResult Edit(Room obj)
        {
            string data = JsonConvert.SerializeObject(obj);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/Room/" + obj.RoomNo, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/Room/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
    }
}
