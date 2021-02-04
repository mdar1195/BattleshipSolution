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
using DevExpress.Xpf.Core;

namespace Battleship_WPFapp_DX
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ThemedWindow
    {
        Battlefield _battlefield;
        public MainWindow()
        {
            InitializeComponent();
            _battlefield = new Battlefield(BattlefieldGrid, LegendCanvas);
            _battlefield.AddTheFleetToTheBattlefield();
            _battlefield.InitializeBattleshipGrid();
            _battlefield.InitializeTheLegend();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button _btn = sender as Button;

            int row = (int)_btn.GetValue(Grid.RowProperty);
            int column = (int)_btn.GetValue(Grid.ColumnProperty);

            _battlefield.AttackAtCoordinate(row, column);
        }
    }
}
