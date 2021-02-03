using BattleshipGrid.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGrid
{
    public enum ShipType
    {
        Carrier,
        Battleship,
        Destroyer,
        Submarine,
        SmallAssaultShip
    }
    public abstract class ShipFactory
    {
        public abstract IShip CreateShip(ShipType type, List<Coordinate> coordinates);
    }

}
