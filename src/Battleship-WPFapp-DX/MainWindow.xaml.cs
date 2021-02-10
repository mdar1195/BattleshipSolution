using System.Windows;
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
