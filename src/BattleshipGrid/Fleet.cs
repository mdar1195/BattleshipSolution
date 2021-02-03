﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGrid
{
    public class Fleet
    {
        //A fleet is composed of a carrier(5 holes),
        //a battleship(4 holes), 1 destroyer(3 holes each), 
        //1 submarine(3 holes) and 
        //1 small assault chip.
        private Carrier _carrier;
        private Battleship _battleship;
        private Destroyer _destroyer;
        private Destroyer _submarine;
        private SmallAssaultShip _assaultShip;

        public Fleet() : base()
        {
           
        }
        public Fleet(Carrier carrier, Battleship battleship, Destroyer destroyer, Destroyer submarine, SmallAssaultShip assaultShip)
        {
            _carrier = carrier;
            _battleship = battleship;
            _destroyer = destroyer;
            _submarine = submarine;
            _assaultShip = assaultShip;
        }

        public Fleet(Ship[] ships)
        {
            _carrier = (Carrier) ships[0];
            _battleship = (Battleship) ships[1];
            _destroyer = (Destroyer) ships[2];
            _submarine = (Destroyer) ships[3];
            _assaultShip = (SmallAssaultShip) ships[4];
        }

        // Returns true if all ships have sank (complete fleet was hit) and false otherwise
        public virtual bool IsGameOver()
        {
            if (_carrier.IsSank() && _battleship.IsSank()
                && _destroyer.IsSank() && _submarine.IsSank()
                && _assaultShip.IsSank())
            {
                return true;
            }

            return false;
        }

        // Returns true if one of the ships was hit and false if none of the ships was hit
        public virtual bool IsHit(Coordinate point)
        {
            if (_carrier.IsHit(point) || _battleship.IsHit(point)
                || _destroyer.IsHit(point) || _submarine.IsHit(point)
                || _assaultShip.IsHit(point))
            {
                return true;
            }
            return false;
        }

        public virtual bool DidSank(Coordinate point)
        {
            if (_carrier.DidSank(point) || _battleship.DidSank(point)
                || _destroyer.DidSank(point) || _submarine.DidSank(point)
                || _assaultShip.DidSank(point))
            {
                return true;
            }
            return false;
        }
    }
}
