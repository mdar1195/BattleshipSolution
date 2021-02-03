using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGrid
{
    public class Carrier : Ship
    {
        //5 holes = 5 coordinates

        public Carrier(List<Coordinate> coordinates)
        {
            _coordinates = coordinates;
        }

    }
}
