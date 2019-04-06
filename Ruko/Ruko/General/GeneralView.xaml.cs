using System.Windows.Controls;
using System.Windows.Input;

namespace Ruko
{
    /// <summary>
    /// Interaction logic for GeneralView.xaml
    /// </summary>
    public partial class GeneralView : UserControl
    {
        public GeneralView()
        {
            InitializeComponent();
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //((sender as DataGridRow).DataContext as CustomerViewModel).ToggleProfileState(true, true);
            ((sender as DataGridRow).DataContext as CustomerViewModel).Open(true);
        }
    }
}
