using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Login;
using MVVM;
using static Utilities.Functions;

namespace Managers
{
    public abstract class ManagerViewModel<TWindow, TModel> : ViewModel<TModel>, IManager<TWindow>, IManager
        where TWindow : Window
    {
        /// <summary>
        /// The associated main window for the application
        /// </summary>
        public TWindow Window { get; set; }
        object IManager.Window => Window;

        /// <summary>
        /// The name of the manager/application
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The absolute root of the application, likely the current directory
        /// </summary>
        public string Root => Directory.GetCurrentDirectory();

        /// <summary>
        /// Internal root of compiled resources
        /// </summary>
        public virtual string InternalRoot => "Resources\\";

        /// <summary>
        /// External root of user accessible resources
        /// </summary>
        public virtual string ExternalRoot => $"{Root}\\{Name}";

        /// <summary>
        /// The login controller for this Manager
        /// </summary>
        public LoginViewModel LoginController { get; }

        public ManagerViewModel(TWindow window, TModel model, string name = null) : base(model)
        {
            Window = window;
            Name = ReturnIfNotNEW(name, GetType().Namespace);
            LoginController = new LoginViewModel($"{Name} Login", Name);
            ManagerInitialize();
        }

        /// <summary>
        /// Serves as the managers central routing function for initialization. Use this to set the order of operations for various initialization functions
        /// Basic implementation is to Call Login() first then check for IsLoggedIn. If that's true then handle initialization - else close the main window (which terminates the program)
        /// </summary>
        public virtual void ManagerInitialize()
        {
            if (!Login())
            {
                Window.Close();
            }
        }

        /// <summary>
        /// Handles the login process.
        /// Basic implpementation is to called the LoginController.InitiateLogin()
        /// </summary>
        public virtual bool Login() => LoginController.InitiateLogin();
    }
}