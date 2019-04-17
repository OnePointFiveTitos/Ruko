using System.Windows;

namespace Ruko
{
    /// <summary>
    /// Interaction logic for RukoWindow.xaml
    /// </summary>
    public partial class RukoWindow : Window
    {
        public RukoWindow()
        {
            InitializeComponent();
            DataContext = new RukoViewModel(this, new RukoModel());
        }
    }
}
