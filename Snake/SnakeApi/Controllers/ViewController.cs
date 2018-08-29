using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Snake.Models;

namespace SnakeApi.Controllers
{
    public class ViewController : Controller
    {
        public async Task<ActionResult> Index()
        {
            ViewBag.Title = "Home Page";
            HttpClient client = new HttpClient();
            string BaseAddress = "http://localhost:62912/SnakeGame/";
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            string json = await client.GetStringAsync(BaseAddress+"GetMap");
            Map map = JsonConvert.DeserializeObject<Map>(json);
            ViewBag.xSize = map._xSize;
            ViewBag.ySize = map._ySize;

            json = await client.GetStringAsync(BaseAddress+"GetSnakePosition");
            Position position = JsonConvert.DeserializeObject<Position>(json);
            ViewBag.position = position;
            
            json = await client.GetStringAsync(BaseAddress + "GetSnakeDirection");
            ViewBag.direction = (int)JsonConvert.DeserializeObject<Direction>(json);
            return View(position);
        }
        public static void PostDirection(int Direction)
        {
            HttpClient client = new HttpClient();
            string BaseAddress = "http://localhost:62912/SnakeGame/";
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = new StringContent(JsonConvert.SerializeObject(Direction));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var request = client.PostAsync(BaseAddress + "PostSnakeDirection", content);

            var response = request.Result.Content.ReadAsStringAsync().Result;
        }

        public static void PostPosition(int x, int y)
        {
            HttpClient client = new HttpClient();
            string BaseAddress = "http://localhost:62912/SnakeGame/";
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Position position = new Position(x, y);

            var content = new StringContent(JsonConvert.SerializeObject(position));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var request = client.PostAsync(BaseAddress + "PostSnakePosition", content);

            var response = request.Result.Content.ReadAsStringAsync().Result;
        }
    }
}
