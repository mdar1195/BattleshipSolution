
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

        private BattleshipGridModel _battleshipGridModel;

        private Grid _battlefieldUiGrid;

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
            Button button = parameter as Button;

            int row = (int)button.GetValue(Grid.RowProperty);
            int column = (int)button.GetValue(Grid.ColumnProperty);

            ResultOfAttack result = _battleshipGridModel.AttackAtCoordinate(row, column);

            if (result == ResultOfAttack.Hit)
            {
                MessageBox.Show("It's a hit");
                button.Content = TARGET_HIT_CHAR;
            }
            else if (result == ResultOfAttack.Sank)
            {
                MessageBox.Show("It sank");
                button.Content = TARGET_HIT_CHAR;
            }
            else if (result == ResultOfAttack.GameOver)
            {
                MessageBox.Show("It's game over");
                button.Content = TARGET_HIT_CHAR;
            }
            else if (result == ResultOfAttack.Miss)
            {
                MessageBox.Show("It's a miss");
                button.Content = TARGET_MISSED_CHAR;
            }
            button.IsEnabled = false;
        }
        public BattlefieldViewModel(Grid battlefieldGrid)
        {
            _battlefieldUiGrid = battlefieldGrid;
        }
        public LegendModel Legend
        {
            get;
            set;
        }
        private UIElement GetElementInGridPosition(int column, int row)
        {
            if (_battlefieldUiGrid == null)
                return null;
            foreach (UIElement element in _battlefieldUiGrid.Children)
            {
                if (Grid.GetColumn(element) == column && Grid.GetRow(element) == row)
                    return element;
            }
            return null;
        }
        private void LoadLegend()
        {
            LegendModel legendCharacters = new LegendModel();

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
        private void GetShipCoordinatesFromUi()
        {
            foreach (UIElement element in _battlefieldUiGrid.Children)
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
        private void InitializeBattleshipGridModel()
        {
            GetShipCoordinatesFromUi();
            _battleshipGridModel = new BattleshipGridModel(_carrierCoordinates, _battleshipCoordinates, _destroyerCoordinates, _submarineCoordinates, _smallAssaultShipCoordinates);
        }
        public void LoadBattleshipGame()
        {
            //this will populate the UI Grid
            AddACarrierToUi();
            AddABattelshipToUi();
            AddADestroyerToUi();
            AddASubmarineToUi();
            AddASmallAssaultShipToUi();

            InitializeBattleshipGridModel();
            LoadLegend();
        }  
    }
}
