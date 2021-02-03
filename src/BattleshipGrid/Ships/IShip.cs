using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGrid.Ships
{
    public interface IShip
    {
        public bool IsHit(Coordinate point);
        public bool DidSank(Coordinate point);
    }
}
