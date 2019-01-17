using Login;
using MVVM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Utilities.Functions;

namespace Managers
{
    ////Basic implementation of Initialize() and Login()
    //  public override void Initialize()
    //  {
    //      //call the login function to initiate the login process
    //      if (Login())
    //      {
    //          //handle initialization logic here
    //      }
    //      else
    //      {
    //          //If the login gets cancelled (ie the window gets closed), close the ViewModel's Window (This is the main window for the application)
    //          ViewModel.Window.Close();
    //      }
    //  }
    //  public override bool Login() => LoginController.InitiateLogin();
    /// <summary>
    /// An abstract class that implements basic functionality for an appplication manager
    /// The purpose of this class is to act as half of the central compliment pair where:
    ///     This class serves as the central backend point
    ///     The ViewModel class serves as the central frontend point
    ///     
    /// NOTE: The manager is responsible for resource management- however resources have not yet been implemented simply because I don't know how I want to implement them
    /// </summary>
    /// <typeparam name="TMainViewModel">Associated manager viewmodel</typeparam>
    public abstract class Manager<TMainWindow, TMainViewModel> : IManager<TMainWindow, TMainViewModel>, IManager
    {
        /// <summary>
        /// The associated main window for the application
        /// </summary>
        public TMainWindow Window { get; set; }
        object IManager.Window => Window;

        ///// <summary>
        ///// The associated main ViewModel of this Manager
        ///// </summary>
        //public TMainViewModel ViewModel { get; set; }
        //object IManager.ViewModel => ViewModel;

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

        /// <summary>
        /// Creates a manager for an application. Pairs with and encapsulates a ViewModel
        /// </summary>
        /// <param name="viewModel">The associated manager viewmodel for this manager. Should (or must, idk atm) be of type ViewModel</param>
        /// <param name="name">The name of this manager/application; If a name is not provided, it will be set to the the Type.Name</param>
        /// <param name="loginController">An optional loginviewmodel that serves as the login controller</param>
        public Manager(TMainWindow window, string name = null)
        {
            Window = window;
            Name = ReturnIfNotNEW(name, GetType().Name);
            LoginController = new LoginViewModel($"{Name} Login", Name);
            Initialize();
        }

        /// <summary>
        /// Serves as the managers central routing function for initialization. Use this to set the order of operations for various initialization functions
        /// Basic implementation is to Call Login() first then check for IsLoggedIn. If that's true then handle initialization - else close the main window (which terminates the program)
        /// </summary>
        public abstract void Initialize();

        /// <summary>
        /// Handles the login process.
        /// Basic implpementation is to called the LoginController.InitiateLogin()
        /// </summary>
        public abstract bool Login();
    }
}