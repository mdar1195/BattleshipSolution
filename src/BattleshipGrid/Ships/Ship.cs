using BattleshipGrid.Ships;
using System.Collections.Generic;

namespace BattleshipGrid
{
    public abstract class Ship : IShip
    {
        protected List<Coordinate> _coordinates = new List<Coordinate>();
        protected int nrOfHits = 0;
        // returns true if the ship was hit and false otherwise
        public bool IsHit(Coordinate point)
        {
            foreach (Coordinate coordinate in _coordinates)
            {
                if (coordinate.Equals(point))
                {
                    nrOfHits++;
                    return true;
                }
            }
            return false;
        }
        // returns true if the ship has sink and false otherwise
        public bool DidSank(Coordinate point)
        {
            bool isPresent = false;
            foreach (Coordinate coordinate in _coordinates)
            {
                if (coordinate.Equals(point))
                {
                    isPresent = true;
                }
            }
            if (!isPresent)
            {
                return false;
            }
            return IsSank();
        }
        //returns true if the ship is completetly hit and false otherwise
        public bool IsSank()
        {
            if (_coordinates.Count == nrOfHits)
            {
                return true;
            }
            return false;
        }
    }
}
