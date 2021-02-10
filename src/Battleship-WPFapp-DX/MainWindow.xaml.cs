using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Battleship_WPFapp_DX.ViewModel;
using DevExpress.Xpf.Core;

namespace Battleship_WPFapp_DX
{
    public partial class MainWindow : ThemedWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BattlefieldViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            BattlefieldViewModel battlefieldViewModelObject =
               new BattlefieldViewModel(BattlefieldViewControl.BattlefieldGrid);
            battlefieldViewModelObject.LoadBattleshipGame();

            BattlefieldViewControl.DataContext = battlefieldViewModelObject;
        }
    }
}
