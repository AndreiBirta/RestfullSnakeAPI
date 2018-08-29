using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Snake.Models
{
    public class Map
    {
        public int _xSize { get; set; }
        public int _ySize { get; set; }

        public Map(int xSize = 10, int ySize = 10)
        {
            _xSize = xSize;
            _ySize = ySize;
        }
        
    }
}