using System.Collections.Generic;

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
