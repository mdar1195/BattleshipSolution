using BattleshipGrid;
using BattleshipGrid.Factory;
using System.Collections.Generic;
using System.ComponentModel;

namespace Battleship_WPFapp_DX.Model
{
    class BattleshipGridModel : INotifyPropertyChanged
    {
        private BattleshipGrid.BattleshipGrid _battleshipGrid;
        private bool _isNotGameOver=true;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public bool IsNotGameOver
        {
            get
            {
                return _isNotGameOver;
            }
            set
            {
                if (_isNotGameOver != value)
                {
                    _isNotGameOver = value;
                    OnPropertyChanged("IsNotGameOver");
                }
            }
        }

        public BattleshipGridModel(List<Coordinate> carrierCoordinates, List<Coordinate> battleshipCoordinates, 
            List<Coordinate> destroyerCoordinates, List<Coordinate> submarineCoordinates, List<Coordinate> smallAssaultShipCoordinates)
        {
            Carrier carrier;
            Battleship battleship;
            Destroyer destroyer;
            Submarine submarine;
            SmallAssaultShip assaultShip;

            ShipFactoryCreator factory = new ShipFactoryCreator();
            carrier = (Carrier)factory.CreateShip(ShipType.Carrier, carrierCoordinates);
            battleship = (Battleship)factory.CreateShip(ShipType.Battleship, battleshipCoordinates);
            destroyer = (Destroyer)factory.CreateShip(ShipType.Destroyer, destroyerCoordinates);
            submarine = (Submarine)factory.CreateShip(ShipType.Submarine, submarineCoordinates);
            assaultShip = (SmallAssaultShip)factory.CreateShip(ShipType.SmallAssaultShip, smallAssaultShipCoordinates);

            _battleshipGrid = new BattleshipGrid.BattleshipGrid(new Fleet(carrier, battleship, destroyer, submarine, assaultShip));
        }
        public ResultOfAttack AttackAtCoordinate(int row, int column)
        {
            ResultOfAttack result = _battleshipGrid.Attack(new Coordinate(row, column));
            IsNotGameOver = result == ResultOfAttack.GameOver ? false : true;
            return result;
        }
    }
}
