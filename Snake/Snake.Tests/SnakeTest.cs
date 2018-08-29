using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Snake.Models;

namespace Snake.Tests
{
    [TestClass]
    public class SnakeTest
    {
        [TestMethod]
        public async Task GetMap_ShouldGetMapObject()
        {
            //set
            HttpClient client = new HttpClient();
            string BaseAddress = "http://localhost:62912/SnakeGame/";
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //act
            string json = await client.GetStringAsync(BaseAddress + "GetMap");
            Map map = JsonConvert.DeserializeObject<Map>(json);
            
            //assert
            Assert.IsNotNull(map);
        }

        [TestMethod]
        public async Task GetSnakePosition_ShouldGetPostionObject()
        {
            //set
            HttpClient client = new HttpClient();
            string BaseAddress = "http://localhost:62912/SnakeGame/";
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //act
            string json = await client.GetStringAsync(BaseAddress + "GetSnakePosition");
            Position position = JsonConvert.DeserializeObject<Position>(json);

            //assert
            Assert.IsNotNull(position);
        }
        [TestMethod]
        public async Task GetSnakeDirection_ShouldGetSnakeDirection()
        {
            //set
            HttpClient client = new HttpClient();
            string BaseAddress = "http://localhost:62912/SnakeGame/";
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //act
            string json = await client.GetStringAsync(BaseAddress + "GetSnakeDirection");
            Direction direction = JsonConvert.DeserializeObject<Direction>(json);

            //assert
            Assert.IsNotNull(direction);
        }

        [TestMethod]
        public void PostPosition_ShouldGetOKResponse()
        {
            //set
            Random r = new Random();
            HttpClient client = new HttpClient();
            string BaseAddress = "http://localhost:62912/SnakeGame/";
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Position position = new Position(r.Next(), r.Next());
            var content = new StringContent(JsonConvert.SerializeObject(position));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //act
            var request = client.PostAsync(BaseAddress + "PostSnakePosition", content);
            var response = request.Result.Content.ReadAsStringAsync().Result;

            //assert
            Assert.IsNotNull(response);

        }

        [TestMethod]
        public void PostDirection_ShouldGetOKResponse()
        {
            //set
            HttpClient client = new HttpClient();
            string BaseAddress = "http://localhost:62912/SnakeGame/";
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Direction direction = Direction.Down;
            var content = new StringContent(JsonConvert.SerializeObject(direction));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //act
            var request = client.PostAsync(BaseAddress + "PostSnakeDirection", content);
            var response = request.Result.Content.ReadAsStringAsync().Result;

            //assert
            Assert.IsNotNull(response);
        }
    }
}
