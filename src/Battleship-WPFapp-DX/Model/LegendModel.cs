﻿using System.ComponentModel;

namespace Battleship_WPFapp_DX.Model
{
    class LegendModel : INotifyPropertyChanged
    {
        string _carrierCharacter;
        string _battleshipCharacter;
        string _destroyerCharacter;
        string _submarineCharacter;
        string _smallAssaultShipCharacter;

        public string CarrierCharacter 
        {
            get
            {
                return _carrierCharacter;
            }
            set
            {
                if (_carrierCharacter != value)
                {
                    _carrierCharacter = value;
                    OnPropertyChanged("CarrierCharacter");
                }
            }
        }
        public string BattleshipCharacter
        {
            get
            {
                return _battleshipCharacter;
            }
            set
            {
                if (_battleshipCharacter != value)
                {
                    _battleshipCharacter = value;
                    OnPropertyChanged("BattleshipCharacter");
                }
            }
        }
        public string DestroyerCharacter
        {
            get
            {
                return _destroyerCharacter;
            }
            set
            {
                if (_destroyerCharacter != value)
                {
                    _destroyerCharacter = value;
                    OnPropertyChanged("DestroyerCharacter");
                }
            }
        }
        public string SubmarineCharacter
        {
            get
            {
                return _submarineCharacter;
            }
            set
            {
                if (_submarineCharacter != value)
                {
                    _submarineCharacter = value;
                    OnPropertyChanged("SubmarineCharacter");
                }
            }
        }
        public string SmallAssaultShipCharacter
        {
            get
            {
                return _smallAssaultShipCharacter;
            }
            set
            {
                if (_smallAssaultShipCharacter != value)
                {
                    _smallAssaultShipCharacter = value;
                    OnPropertyChanged("SmallAssaultShipCharacter");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
