using System.Collections.Generic;

namespace BattleshipGrid
{
    public class Battleship : Ship
    {
        public Battleship(List<Coordinate> coordinates)
        {
            _coordinates = coordinates;
        }
    }
}
