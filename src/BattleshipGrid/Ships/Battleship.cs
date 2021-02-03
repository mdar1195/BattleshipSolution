using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGrid
{
    public class Battleship : Ship
    {
        //4 holes = 4 coordinates
        public Battleship(List<Coordinate> coordinates)
        {
            _coordinates = coordinates;
        }
    }
}
