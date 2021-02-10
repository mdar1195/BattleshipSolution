using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Battleship_WPFapp_DX.View
{
    public partial class BattlefieldView : UserControl
    {
        public BattlefieldView()
        {
            InitializeComponent();
            this.DataContext = new ViewModel.BattlefieldViewModel(BattlefieldGrid);
        }
    }
}
