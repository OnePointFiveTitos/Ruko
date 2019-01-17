using Login;
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
    /// Interaction logic for RukoWindow.xaml
    /// </summary>
    public partial class RukoWindow : Window
    {
        RukoManager manager;
        public RukoWindow()
        {
            InitializeComponent();
            manager = new RukoManager(this, "Ruko");
        }
    }
}
