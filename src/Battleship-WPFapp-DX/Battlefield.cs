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
        private const string CARRIER_CHAR = "🚢";
        private const string BATTLESHIP_CHAR = "🛳";
        private const string DESTROYER_CHAR = "🚀";
        private const string SUBMARINE_CHAR = "🛁";
        private const string ASSAULT_SHIP_CHAR = "⛵️";

        private const string TARGET_HIT_CHAR = "🎯";
        private const string TARGET_MISSED_CHAR = "✖️";

        private const string CARRIER_PLACEHOLDER_LABEL = "carrier_placeholder";
        private const string BATTLESHIP_PLACEHOLDER_LABEL = "battleship_placeholder";
        private const string DESTROYER_PLACEHOLDER_LABEL = "destroyer_placeholder";
        private const string SUBMARINE_PLACEHOLDER_LABEL = "submarine_placeholder";
        private const string ASSAULTSHIP_PLACEHOLDER_LABEL = "assault_ship_placeholder";

        private Grid _battlefieldGrid;
        private Canvas _legendCanvas;
        private List<Coordinate> _carrierCoordinates = new List<Coordinate>(5);
        private List<Coordinate> _battleshipCoordinates = new List<Coordinate>(4);
        private List<Coordinate> _destroyerCoordinates = new List<Coordinate>(3);
        private List<Coordinate> _submarineCoordinates = new List<Coordinate>(3);
        private List<Coordinate> _smallAssaultShipCoordinates = new List<Coordinate>(1);

        private BattleshipGrid.BattleshipGrid _battleshipGrid;
#region
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
            btn.Content = CARRIER_CHAR;
            btn = (Button)GetElementInGridPosition(2, 1);
            btn.Content = CARRIER_CHAR;
            btn = (Button)GetElementInGridPosition(3, 1);
            btn.Content = CARRIER_CHAR;
            btn = (Button)GetElementInGridPosition(4, 1);
            btn.Content = CARRIER_CHAR;
            btn = (Button)GetElementInGridPosition(5, 1);
            btn.Content = CARRIER_CHAR;
        }
        private void AddABattelship()
        {
            Button btn = (Button)GetElementInGridPosition(7, 1);
            btn.Content = BATTLESHIP_CHAR;
            btn = (Button)GetElementInGridPosition(7, 2);
            btn.Content = BATTLESHIP_CHAR;
            btn = (Button)GetElementInGridPosition(7, 3);
            btn.Content = BATTLESHIP_CHAR;
            btn = (Button)GetElementInGridPosition(7, 4);
            btn.Content = BATTLESHIP_CHAR;
        }
        private void AddADestroyer()
        {
            Button btn = (Button)GetElementInGridPosition(2, 5);
            btn.Content = DESTROYER_CHAR;
            btn = (Button)GetElementInGridPosition(3, 5);
            btn.Content = DESTROYER_CHAR;
            btn = (Button)GetElementInGridPosition(4, 5);
            btn.Content = DESTROYER_CHAR;
        }
        private void AddASubmarine()
        {
            Button btn = (Button)GetElementInGridPosition(5, 7);
            btn.Content = SUBMARINE_CHAR;
            btn = (Button)GetElementInGridPosition(5, 8);
            btn.Content = SUBMARINE_CHAR;
            btn = (Button)GetElementInGridPosition(5, 9);
            btn.Content = SUBMARINE_CHAR;
        }
        private void AddASmallAssaultShip()
        {
            Button btn = (Button)GetElementInGridPosition(9, 8);
            btn.Content = ASSAULT_SHIP_CHAR;
        }
        private void InitializeCoordinates()
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
                        if (btn.Content.Equals(CARRIER_CHAR))
                        {
                            _carrierCoordinates.Add(new Coordinate(row, column));
                        }
                        else if (btn.Content.Equals(BATTLESHIP_CHAR))
                        {
                            _battleshipCoordinates.Add(new Coordinate(row, column));
                        }
                        else if (btn.Content.Equals(DESTROYER_CHAR))
                        {
                            _destroyerCoordinates.Add(new Coordinate(row, column));
                        }
                        else if (btn.Content.Equals(SUBMARINE_CHAR))
                        {
                            _submarineCoordinates.Add(new Coordinate(row, column));
                        }
                        else if (btn.Content.Equals(ASSAULT_SHIP_CHAR))
                        {
                            _smallAssaultShipCoordinates.Add(new Coordinate(row, column));
                        }
                    }
                }
            }

        }
        #endregion
        public Battlefield(Grid battlefieldGrid, Canvas legendCanvas)
        {
            _battlefieldGrid = battlefieldGrid;
            _legendCanvas = legendCanvas;
        }

        public void InitializeTheLegend()
        {
            if (_legendCanvas == null)
                return;
            foreach (UIElement element in _legendCanvas.Children)
            {
                if (element is Label)
                {
                    Label label = (Label)element;
                    if (label.Content == null)
                    {
                        StringBuilder s = new StringBuilder();
                        if (label.Name.Equals(CARRIER_PLACEHOLDER_LABEL))
                        {
                            s.Append(CARRIER_CHAR);
                        }
                        else if (label.Name.Equals(BATTLESHIP_PLACEHOLDER_LABEL))
                        {
                            s.Append(BATTLESHIP_CHAR);
                        }
                        else if (label.Name.Equals(DESTROYER_PLACEHOLDER_LABEL))
                        {
                            s.Append(DESTROYER_CHAR);
                        }
                        else if (label.Name.Equals(SUBMARINE_PLACEHOLDER_LABEL))
                        {
                            s.Append(SUBMARINE_CHAR);
                        }
                        else if (label.Name.Equals(ASSAULTSHIP_PLACEHOLDER_LABEL))
                        {
                            s.Append(ASSAULT_SHIP_CHAR);
                        }
                        label.Content = s.ToString();
                    }
                }
            }
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

        public void InitializeBattleshipGrid()
        {
            InitializeCoordinates();
            Carrier carrier;
            Battleship battleship;
            Destroyer destroyer;
            Submarine submarine;
            SmallAssaultShip assaultShip;

            ShipFactoryCreator factory = new ShipFactoryCreator();
            carrier = (Carrier)factory.CreateShip(ShipType.Carrier, _carrierCoordinates);
            battleship = (Battleship)factory.CreateShip(ShipType.Battleship, _battleshipCoordinates);
            destroyer = (Destroyer)factory.CreateShip(ShipType.Destroyer, _destroyerCoordinates);
            submarine = (Submarine)factory.CreateShip(ShipType.Submarine, _submarineCoordinates);
            assaultShip = (SmallAssaultShip)factory.CreateShip(ShipType.SmallAssaultShip, _smallAssaultShipCoordinates);

            _battleshipGrid = new BattleshipGrid.BattleshipGrid(new Fleet(carrier, battleship, destroyer, submarine, assaultShip));
        }

        public void AttackAtCoordinate(int row, int column)
        {
            ResultOfAttack result = _battleshipGrid.Attack(new Coordinate(row, column));
            Button btn = (Button)GetElementInGridPosition(column, row);
            if (result == ResultOfAttack.Hit)
            {
                MessageBox.Show("It's a hit");
                btn.Content = TARGET_HIT_CHAR;
            }
            else if (result == ResultOfAttack.Sank)
            {
                MessageBox.Show("It sank");
                btn.Content = TARGET_HIT_CHAR;
            }
            else if (result == ResultOfAttack.GameOver)
            {
                MessageBox.Show("It's game over");
                btn.Content = TARGET_HIT_CHAR;
            }
            else if (result == ResultOfAttack.Miss)
            {
                MessageBox.Show("It's a miss");
                btn.Content = TARGET_MISSED_CHAR;
            }
            btn.IsEnabled = false;
        }
    }
}
