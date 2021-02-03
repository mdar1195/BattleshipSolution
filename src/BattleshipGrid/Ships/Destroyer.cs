using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGrid
{
    public class Destroyer : Ship
    {
        //3 holes - 3 coordinates
        public Destroyer(List<Coordinate> coordinates)
        {
            _coordinates = coordinates;
        }
    }
}
