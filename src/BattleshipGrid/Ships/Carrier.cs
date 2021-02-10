using System.Collections.Generic;

namespace BattleshipGrid
{
    public class Carrier : Ship
    {
        public Carrier(List<Coordinate> coordinates)
        {
            _coordinates = coordinates;
        }

    }
}
