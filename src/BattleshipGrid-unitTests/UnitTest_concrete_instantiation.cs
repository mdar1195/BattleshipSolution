using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleshipGrid.Factory;
using System.Collections.Generic;
using BattleshipGrid;

namespace BattleshipGrid_unitTests
{
    [TestClass]
    public class UnitTest_concrete_instantiation
    {
        private BattleshipGrid.BattleshipGrid _battleshipGrid;
        private void InitializeTheBattleshipGrid()
        {
            Ship[] ships = new Ship[5];

            List<Coordinate>[] shipsCoordinates = new List<Coordinate>[5];

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

            Fleet fleet = new BattleshipGrid.Fleet(ships);
            _battleshipGrid = new BattleshipGrid.BattleshipGrid(fleet);

        }

        [TestMethod]
        public void TestAttack_IsHit()
        {
            InitializeTheBattleshipGrid();
            Coordinate pointOfAttack = new Coordinate(5, 4);
            ResultOfAttack result = _battleshipGrid.Attack(pointOfAttack);
            Assert.IsTrue(result == ResultOfAttack.Hit);
        }

        [TestMethod]
        public void TestAttack_IsMiss()
        {
            InitializeTheBattleshipGrid();
            Coordinate pointOfAttack = new Coordinate(6, 5);
            ResultOfAttack result = _battleshipGrid.Attack(pointOfAttack);
            Assert.IsTrue(result == ResultOfAttack.Miss);
        }

        [TestMethod]
        public void TestAttack_IsSank_OnSmallAssaultShip()
        {
            InitializeTheBattleshipGrid();
            Coordinate pointOfAttack = new Coordinate(8, 9);
            ResultOfAttack result = _battleshipGrid.Attack(pointOfAttack);
            Assert.IsTrue(result == ResultOfAttack.Sank);
        }

        [TestMethod]
        public void TestAttack_IsSank_OnDestroyerShip()
        {
            InitializeTheBattleshipGrid();
            Coordinate pointOfAttack = new Coordinate(7, 5);
            ResultOfAttack result = _battleshipGrid.Attack(pointOfAttack);
            Assert.IsTrue(result == ResultOfAttack.Hit);

            pointOfAttack.Latitude = 8;
            pointOfAttack.Longitude = 5;
            result = _battleshipGrid.Attack(pointOfAttack);
            Assert.IsTrue(result == ResultOfAttack.Hit);

            pointOfAttack.Latitude = 9;
            pointOfAttack.Longitude = 5;
            result = _battleshipGrid.Attack(pointOfAttack);
            Assert.IsTrue(result == ResultOfAttack.Sank);
        }

        [TestMethod]
        public void TestAttack_IsGameOver()
        {
            InitializeTheBattleshipGrid();
            Coordinate pointOfAttack = new Coordinate(7, 5);
            ResultOfAttack result = _battleshipGrid.Attack(pointOfAttack);
            Assert.IsTrue(result == ResultOfAttack.Hit);

            pointOfAttack.Latitude = 8;
            pointOfAttack.Longitude = 5;
            result = _battleshipGrid.Attack(pointOfAttack);
            Assert.IsTrue(result == ResultOfAttack.Hit);

            pointOfAttack.Latitude = 9;
            pointOfAttack.Longitude = 5;
            result = _battleshipGrid.Attack(pointOfAttack);
            Assert.IsTrue(result == ResultOfAttack.Sank);

            pointOfAttack.Latitude = 1;
            pointOfAttack.Longitude = 1;
            result = _battleshipGrid.Attack(pointOfAttack);
            Assert.IsTrue(result == ResultOfAttack.Hit);

            pointOfAttack.Latitude = 1;
            pointOfAttack.Longitude = 2;
            result = _battleshipGrid.Attack(pointOfAttack);
            Assert.IsTrue(result == ResultOfAttack.Hit);

            pointOfAttack.Latitude = 1;
            pointOfAttack.Longitude = 3;
            result = _battleshipGrid.Attack(pointOfAttack);
            Assert.IsTrue(result == ResultOfAttack.Hit);

            pointOfAttack.Latitude = 1;
            pointOfAttack.Longitude = 4;
            result = _battleshipGrid.Attack(pointOfAttack);
            Assert.IsTrue(result == ResultOfAttack.Hit);

            pointOfAttack.Latitude = 1;
            pointOfAttack.Longitude = 5;
            result = _battleshipGrid.Attack(pointOfAttack);
            Assert.IsTrue(result == ResultOfAttack.Sank);

            pointOfAttack.Latitude = 1;
            pointOfAttack.Longitude = 7;
            result = _battleshipGrid.Attack(pointOfAttack);
            Assert.IsTrue(result == ResultOfAttack.Hit);

            pointOfAttack.Latitude = 2;
            pointOfAttack.Longitude = 7;
            result = _battleshipGrid.Attack(pointOfAttack);
            Assert.IsTrue(result == ResultOfAttack.Hit);

            pointOfAttack.Latitude = 3;
            pointOfAttack.Longitude = 7;
            result = _battleshipGrid.Attack(pointOfAttack);
            Assert.IsTrue(result == ResultOfAttack.Hit);

            pointOfAttack.Latitude = 4;
            pointOfAttack.Longitude = 7;
            result = _battleshipGrid.Attack(pointOfAttack);
            Assert.IsTrue(result == ResultOfAttack.Sank);

            pointOfAttack.Latitude = 5;
            pointOfAttack.Longitude = 2;
            result = _battleshipGrid.Attack(pointOfAttack);
            Assert.IsTrue(result == ResultOfAttack.Hit);

            pointOfAttack.Latitude = 5;
            pointOfAttack.Longitude = 3;
            result = _battleshipGrid.Attack(pointOfAttack);
            Assert.IsTrue(result == ResultOfAttack.Hit);

            pointOfAttack.Latitude = 5;
            pointOfAttack.Longitude = 4;
            result = _battleshipGrid.Attack(pointOfAttack);
            Assert.IsTrue(result == ResultOfAttack.Sank);

            pointOfAttack.Latitude = 8;
            pointOfAttack.Longitude = 9;
            result = _battleshipGrid.Attack(pointOfAttack);
            Assert.IsTrue(result == ResultOfAttack.GameOver);
        }
    }
}
