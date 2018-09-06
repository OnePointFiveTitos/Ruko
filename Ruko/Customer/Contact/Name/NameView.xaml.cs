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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ruko
{
    /// <summary>
    /// Interaction logic for NameView.xaml
    /// </summary>
    public partial class NameView : UserControl
    {
        public NameView()
        {
            InitializeComponent();
            DataContext = new NameViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as NameViewModel).IsEditable = !(DataContext as NameViewModel).IsEditable;
        }
    }
}
