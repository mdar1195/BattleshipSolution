using System;
using BattleshipGrid;
using BattleshipGrid.Factory;
using System.Collections.Generic;

namespace Battleship_problem_consoleApp
{
    class Program
    {
        public Fleet _fleet;
        public void InitializeTheFleet()
        {
            Ship[] ships = new Ship[5];

            List<Coordinate> carrierCoordinates = new List<Coordinate>(5);
            carrierCoordinates.Add(new Coordinate(1, 1));
            carrierCoordinates.Add(new Coordinate(1, 2));
            carrierCoordinates.Add(new Coordinate(1, 3));
            carrierCoordinates.Add(new Coordinate(1, 4));
            carrierCoordinates.Add(new Coordinate(1, 5));

            List<Coordinate> battleshipCoordinates = new List<Coordinate>(4);
            battleshipCoordinates.Add(new Coordinate(1, 7));
            battleshipCoordinates.Add(new Coordinate(2, 7));
            battleshipCoordinates.Add(new Coordinate(3, 7));
            battleshipCoordinates.Add(new Coordinate(4, 7));

            List<Coordinate> destroyerCoordinates = new List<Coordinate>(3);
            destroyerCoordinates.Add(new Coordinate(5, 2));
            destroyerCoordinates.Add(new Coordinate(5, 3));
            destroyerCoordinates.Add(new Coordinate(5, 4));

            List<Coordinate> submarineCoordinates = new List<Coordinate>(3);
            submarineCoordinates.Add(new Coordinate(7, 5));
            submarineCoordinates.Add(new Coordinate(8, 5));
            submarineCoordinates.Add(new Coordinate(9, 5));

            List<Coordinate> smallAssaultShipCoordinates = new List<Coordinate>(1);
            smallAssaultShipCoordinates.Add(new Coordinate(8, 9));

            ShipFactoryCreator factory = new ShipFactoryCreator();
            ships[0] = (Ship)factory.CreateShip(ShipType.Carrier, carrierCoordinates);
            Console.WriteLine("Created {0}", ships[0].GetType().Name);
            ships[1] = (Ship)factory.CreateShip(ShipType.Battleship, battleshipCoordinates);
            Console.WriteLine("Created {0}", ships[1].GetType().Name);
            ships[2] = (Ship)factory.CreateShip(ShipType.Destroyer, destroyerCoordinates);
            Console.WriteLine("Created {0}", ships[2].GetType().Name);
            ships[3] = (Ship)factory.CreateShip(ShipType.Submarine, submarineCoordinates);
            Console.WriteLine("Created {0}", ships[3].GetType().Name);
            ships[4] = (Ship)factory.CreateShip(ShipType.SmallAssaultShip, smallAssaultShipCoordinates);
            Console.WriteLine("Created {0}", ships[4].GetType().Name);

            _fleet = new BattleshipGrid.Fleet(ships);

        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.InitializeTheFleet();
            BattleshipGrid.BattleshipGrid battleshipGrid = new BattleshipGrid.BattleshipGrid(p._fleet);

            Coordinate hitPoint = new Coordinate(7, 5);
            Console.WriteLine("IsHit(7,5) " + battleshipGrid.Attack(hitPoint));
            hitPoint = new Coordinate(8, 9);
            Console.WriteLine("IsHit(8,9) " + battleshipGrid.Attack(hitPoint));
        }
    }
}
