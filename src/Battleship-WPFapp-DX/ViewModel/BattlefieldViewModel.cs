
using BattleshipGrid;
using BattleshipGrid.Factory;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Battleship_WPFapp_DX.Model;
using System.Windows.Input;
using DevExpress.Mvvm;

namespace Battleship_WPFapp_DX.ViewModel
{
    class BattlefieldViewModel
    {
        private const string CARRIER_CHAR = "🚢";
        private const string BATTLESHIP_CHAR = "🛳";
        private const string DESTROYER_CHAR = "🚀";
        private const string SUBMARINE_CHAR = "🛁";
        private const string ASSAULT_SHIP_CHAR = "⛵️";

        private const string TARGET_HIT_CHAR = "🎯";
        private const string TARGET_MISSED_CHAR = "✖️";

        private List<Coordinate> _carrierCoordinates = new List<Coordinate>(5);
        private List<Coordinate> _battleshipCoordinates = new List<Coordinate>(4);
        private List<Coordinate> _destroyerCoordinates = new List<Coordinate>(3);
        private List<Coordinate> _submarineCoordinates = new List<Coordinate>(3);
        private List<Coordinate> _smallAssaultShipCoordinates = new List<Coordinate>(1);

        private BattleshipGrid.BattleshipGrid _battleshipGrid;

        private Grid _battlefieldGrid;

        private ICommand _clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                return _clickCommand ?? (_clickCommand = new CommandHandler(AttackAtCoordinate, () => true));
            }
        }

        private void AttackAtCoordinate(object parameter)
        {
            Button _btn = parameter as Button;

            int row = (int)_btn.GetValue(Grid.RowProperty);
            int column = (int)_btn.GetValue(Grid.ColumnProperty);

            AttackAtCoordinate1(row, column);
        }
        public BattlefieldViewModel(Grid battlefieldGrid)
        {
            _battlefieldGrid = battlefieldGrid;
        }
        public Legend Legend
        {
            get;
            set;
        }
        private UIElement GetElementInGridPosition(int column, int row)
        {
            if (_battlefieldGrid == null)
                return null;
            foreach (UIElement element in _battlefieldGrid.Children)
            {
                if (Grid.GetColumn(element) == column && Grid.GetRow(element) == row)
                    return element;
            }
            return null;
        }
        private void LoadLegend()
        {
            Legend legendCharacters = new Legend();

            legendCharacters.CarrierCharacter = CARRIER_CHAR;
            legendCharacters.BattleshipCharacter = BATTLESHIP_CHAR;
            legendCharacters.DestroyerCharacter = DESTROYER_CHAR;
            legendCharacters.SubmarineCharacter = SUBMARINE_CHAR;
            legendCharacters.SmallAssaultShipCharacter = ASSAULT_SHIP_CHAR;

            Legend = legendCharacters;
        }
        private void AddACarrierToUi()
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
        private void AddABattelshipToUi()
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
        private void AddADestroyerToUi()
        {
            Button btn = (Button)GetElementInGridPosition(2, 5);
            btn.Content = DESTROYER_CHAR;
            btn = (Button)GetElementInGridPosition(3, 5);
            btn.Content = DESTROYER_CHAR;
            btn = (Button)GetElementInGridPosition(4, 5);
            btn.Content = DESTROYER_CHAR;
        }
        private void AddASubmarineToUi()
        {
            Button btn = (Button)GetElementInGridPosition(5, 7);
            btn.Content = SUBMARINE_CHAR;
            btn = (Button)GetElementInGridPosition(5, 8);
            btn.Content = SUBMARINE_CHAR;
            btn = (Button)GetElementInGridPosition(5, 9);
            btn.Content = SUBMARINE_CHAR;
        }
        private void AddASmallAssaultShipToUi()
        {
            Button btn = (Button)GetElementInGridPosition(9, 8);
            btn.Content = ASSAULT_SHIP_CHAR;
        }
        private void GetShipCoordinates()
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

        public void LoadBattleshipGame()
        {
            //this will populate the UI Grid
            AddACarrierToUi();
            AddABattelshipToUi();
            AddADestroyerToUi();
            AddASubmarineToUi();
            AddASmallAssaultShipToUi();

            InitializeBattlefieldObject();
            LoadLegend();
        }
        public void InitializeBattlefieldObject()
        {
            GetShipCoordinates();
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
        public void AttackAtCoordinate1(int row, int column)
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
