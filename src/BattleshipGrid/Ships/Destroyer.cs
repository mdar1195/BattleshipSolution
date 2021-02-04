using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGrid
{
    public class Destroyer : Ship
    {
        public Destroyer(List<Coordinate> coordinates)
        {
            _coordinates = coordinates;
        }
    }
}
