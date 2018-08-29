using System.Collections;
using System.Collections.Generic;

namespace Snake.Models
{
    public class Snake
    {
        public int _size { get; set; }
        public Direction _direction;
        public Position _position;

        public Snake(Position position, Direction direction = Direction.Up, int size = 3)
        {
            _position = position;
            _direction = direction;
            _size = size;
        }
    }

    public class Position
    {
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int x { get; set; }
        public int y { get; set; }
    }

    public enum Direction
    {
        Up = 38,
        Down = 40,
        Left = 37,
        Right = 39
    }
}