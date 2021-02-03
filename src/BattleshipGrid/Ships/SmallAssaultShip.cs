using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGrid
{
    public class SmallAssaultShip : Ship
    {
        //1 hole = 1 coordinate
        public SmallAssaultShip(List<Coordinate> coordinates)
        {
            _coordinates = coordinates;
        }
        
    }
}
