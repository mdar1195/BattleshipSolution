using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using BattleshipGrid;
using BattleshipGrid.Factory;

namespace Battleship_WPFapp_DX
{
    class Battlefield
    {
        Grid _battlefieldGrid;
        Ship[] _ships = new Ship[5];
        List<Coordinate> _carrierCoordinates = new List<Coordinate>(5);
        List<Coordinate> _battleshipCoordinates = new List<Coordinate>(4);
        List<Coordinate> _destroyerCoordinates = new List<Coordinate>(3);
        List<Coordinate> _submarineCoordinates = new List<Coordinate>(3);
        List<Coordinate> _smallAssaultShipCoordinates = new List<Coordinate>(1);

        BattleshipGrid.BattleshipGrid _battleshipGrid;

        public Battlefield(Grid battlefieldGrid)
        {
            _battlefieldGrid = battlefieldGrid;
        }

        private UIElement GetElementInGridPosition(int column, int row)
        {
            foreach (UIElement element in _battlefieldGrid.Children)
            {
                if (Grid.GetColumn(element) == column && Grid.GetRow(element) == row)
                    return element;
            }

            return null;
        }

        private void AddACarrier()
        {  
            Button btn = (Button)GetElementInGridPosition(1, 1);
            btn.Content = "C";
            btn = (Button)GetElementInGridPosition(2, 1);
            btn.Content = "C";
            btn = (Button)GetElementInGridPosition(3, 1);
            btn.Content = "C";
            btn = (Button)GetElementInGridPosition(4, 1);
            btn.Content = "C";
            btn = (Button)GetElementInGridPosition(5, 1);
            btn.Content = "C";
        }

        private void AddABattelship()
        {
            Button btn = (Button)GetElementInGridPosition(7, 1);
            btn.Content = "B";
            btn = (Button)GetElementInGridPosition(7, 2);
            btn.Content = "B";
            btn = (Button)GetElementInGridPosition(7, 3);
            btn.Content = "B";
            btn = (Button)GetElementInGridPosition(7, 4);
            btn.Content = "B";
        }

        private void AddADestroyer()
        {
            Button btn = (Button)GetElementInGridPosition(2, 5);
            btn.Content = "D";
            btn = (Button)GetElementInGridPosition(3, 5);
            btn.Content = "D";
            btn = (Button)GetElementInGridPosition(4, 5);
            btn.Content = "D";
        }

        private void AddASubmarine()
        {
            Button btn = (Button)GetElementInGridPosition(5, 7);
            btn.Content = "S";
            btn = (Button)GetElementInGridPosition(5, 8);
            btn.Content = "S";
            btn = (Button)GetElementInGridPosition(5, 9);
            btn.Content = "S";
        }

        private void AddASmallAssaultShip()
        {
            Button btn = (Button)GetElementInGridPosition(9, 8);
            btn.Content = "A";
        }

        public void AddTheFleetToTheBattlefield()
        {
            //this will populate the UI Grid
            AddACarrier();
            AddABattelship();
            AddADestroyer();
            AddASubmarine();
            AddASmallAssaultShip();
        }
        public void InitializeCoordinates()
        {
            foreach (UIElement element in _battlefieldGrid.Children)
            {
                int row = Grid.GetRow(element);
                int column = Grid.GetColumn(element);
                if (element is Button)
                {
                    Button btn = (Button)element;
                    if (btn.Content != null)
                    {
                        if (btn.Content.Equals("C"))
                        {
                            //it's a carrier
                            _carrierCoordinates.Add(new Coordinate(row, column));
                        }
                        else if (btn.Content.Equals("B"))
                        {
                            //it's a battleship
                            _battleshipCoordinates.Add(new Coordinate(row, column));
                        }
                        else if (btn.Content.Equals("D"))
                        {
                            //it's a destroyer
                            _destroyerCoordinates.Add(new Coordinate(row, column));
                        }
                        else if (btn.Content.Equals("S"))
                        {
                            //it's a submarine
                            _submarineCoordinates.Add(new Coordinate(row, column));
                        }
                        else if (btn.Content.Equals("A"))
                        {
                            //it's a small assault ship
                            _smallAssaultShipCoordinates.Add(new Coordinate(row, column));
                        }
                    }
                }
            }

        }
        public void InitializeBattleshipGrid()
        {
            InitializeCoordinates();

            ShipFactoryCreator factory = new ShipFactoryCreator();
            _ships[0] = (Ship)factory.CreateShip(ShipType.Carrier, _carrierCoordinates);
            _ships[1] = (Ship)factory.CreateShip(ShipType.Battleship, _battleshipCoordinates);
            _ships[2] = (Ship)factory.CreateShip(ShipType.Destroyer, _destroyerCoordinates);
            _ships[3] = (Ship)factory.CreateShip(ShipType.Submarine, _submarineCoordinates);
            _ships[4] = (Ship)factory.CreateShip(ShipType.SmallAssaultShip, _smallAssaultShipCoordinates);

            _battleshipGrid = new BattleshipGrid.BattleshipGrid(new Fleet(_ships));
        }

        public void AttackAtCoordinate(int row, int column)
        {
            ResultOfAttack result = _battleshipGrid.Attack(new Coordinate(row, column));
            if (result == ResultOfAttack.Hit)
            {
                MessageBox.Show("It's a hit");
            }
            else if (result == ResultOfAttack.Sank)
            {
                MessageBox.Show("It sank");
            }
            else if (result == ResultOfAttack.GameOver)
            {
                MessageBox.Show("It's game over");
            }
            else if (result == ResultOfAttack.Miss)
            {
                MessageBox.Show("It's a miss");
            }
        }
    }
}
