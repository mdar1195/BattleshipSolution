using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGrid
{
    public enum ResultOfAttack
    {
        None,
        Miss,
        Hit,
        Sank,
        GameOver
    }
    public class BattleshipGrid
    {
        Fleet _fleet;

        public BattleshipGrid(Fleet fleet)
        {
            _fleet = fleet;
        }

        public ResultOfAttack Attack(Coordinate pointOfAttack)
        {
            ResultOfAttack returnValue = ResultOfAttack.None;
            if (_fleet.IsHit(pointOfAttack))
            {
                returnValue = ResultOfAttack.Hit;
            }
            if (_fleet.DidSank(pointOfAttack))
            {
                returnValue = ResultOfAttack.Sank;
            }
            if (_fleet.IsGameOver())
            {
                returnValue = ResultOfAttack.GameOver;
            }
            if (returnValue == ResultOfAttack.None)
            {
                returnValue = ResultOfAttack.Miss;
            }    
            return returnValue;
        }
    }
}
