using BattleshipGrid.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGrid.Factory
{
    public class ShipFactoryCreator : ShipFactory
    {
        public override IShip CreateShip(ShipType type, List<Coordinate> coordinates)
        {
            switch (type)
            {
                case ShipType.Carrier:
                    return new Carrier(coordinates);
                case ShipType.Battleship:
                    return new Battleship(coordinates);
                case ShipType.Destroyer:
                case ShipType.Submarine:
                    return new Destroyer(coordinates);
                case ShipType.SmallAssaultShip:
                    return new SmallAssaultShip(coordinates);
                default:
                    return null;
            }
        }
    }
}
