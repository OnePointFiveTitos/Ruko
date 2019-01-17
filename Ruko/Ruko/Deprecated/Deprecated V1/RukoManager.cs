using Login;
using Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruko
{
    /// <summary>
    /// Serves as the main/root manager for the Ruko application
    /// Should/Must Pair with a RukoViewModel
    /// </summary>
    public class RukoManager : Manager<RukoWindow, RukoViewModel>
    {
        public IEnumerable<CustomerViewModel> Customers => ViewModel.Customers;
        /// <summary>
        /// Serves as the main/root manager for the Ruko application
        /// Should/Must Pair with a RukoViewModel
        /// </summary>
        public RukoManager(RukoWindow window, string name = null) 
            : base(window, name)
        {
            ViewModel = new RukoViewModel(this, new RukoModel());
            Window.DataContext = ViewModel;
            Window.Closing += (sender, e) =>
            {
                Save();
            };
        }
        public override void Initialize()
        {
            //call the login function to initiate the login process
            if (!Login())
            {
                //close the ViewModel's Window (This is the main window for the application)
                Window.Close();
            }
            else
            {
                //handle initialization logic here
            }
        }
        public override bool Login() => LoginController.InitiateLogin();

        public void Save()
        {
            foreach (CustomerViewModel customer in Customers)
            {

            }
        }

        public void Load()
        {

        }
    }
}
