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
    /// Interaction logic for ContactView.xaml
    /// </summary>
    public partial class ContactView : UserControl
    {
        private ContactViewModel viewModel;
        public ContactView()
        {
            InitializeComponent();
            DataContext = viewModel = new ContactViewModel();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Button item = (sender as Button);
            switch (item.Tag.ToString())
            {
                case "Name":
                    viewModel.Names.Add(new NameViewModel());
                    break;
                case "Address":
                    viewModel.Addresses.Add(new AddressViewModel());
                    break;
                case "Email":
                    viewModel.Emails.Add(new EmailViewModel());
                    break;
                case "Phone":
                    viewModel.Phones.Add(new PhoneViewModel());
                    break;
            }
        }
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Button item = (sender as Button);
            switch (item.Tag.ToString())
            {
                case "Name":
                    viewModel.Names.Add(new NameViewModel());
                    break;
                case "Address":
                    viewModel.Names.Add(new NameViewModel());
                    break;
                case "Email":
                    viewModel.Names.Add(new NameViewModel());
                    break;
                case "Phone":
                    viewModel.Names.Add(new NameViewModel());
                    break;
            }
        }
    }
}
