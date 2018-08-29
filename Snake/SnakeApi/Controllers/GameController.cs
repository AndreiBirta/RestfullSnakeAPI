using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Snake.Models;

namespace SnakeApi.Controllers
{
    [RoutePrefix("SnakeGame")]
    public class GameController : ApiController
    {
        public Map map;
        public Snake.Models.Snake snake;

        public GameController()
        {
            Position position = new Position(0,0);
            map = new Map(400, 400);
            snake = new Snake.Models.Snake(position, Direction.Down, 3);
        }

        [HttpGet][Route("GetMap")]
        public Map GetMap()
        {
            return map;
        }

        [HttpGet][Route("GetSnakePosition")]
        public Position GetSnakePosition()
        {
            return snake._position;
        }

        [HttpGet]
        [Route("GetSnakeDirection")]
        public Direction GetSnakeDirection()
        {
            return snake._direction;
        }

        [HttpPost]
        [Route("PostSnakePosition")]
        public StatusCodeResult PostSnakePosition(Position position)
        {
            snake._position = position;
            return StatusCode(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("PostSnakeDirection")]
        public StatusCodeResult PostSnakeDirection(Direction direction)
        {
            snake._direction = direction;
            return StatusCode(HttpStatusCode.OK);
        }
    }
}
