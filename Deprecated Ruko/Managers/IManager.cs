using Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers
{
    public interface IManager<TWindow> : IManager
    {
        new TWindow Window { get; set; }
    }

    /// <summary>
    /// Templates the basic manager with access to a ViewModel, Roots, and Resources, as well as handling basic initialization and login functionality
    /// </summary>
    public interface IManager
    {
        object Window { get; }

        /// <summary>
        /// The name of the manager/application
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The absolute root of the application, likely the current directory
        /// </summary>
        string Root { get; }

        /// <summary>
        /// Internal root of compiled resources
        /// </summary>
        string InternalRoot { get; }

        /// <summary>
        /// External root of user accessible resources
        /// </summary>
        string ExternalRoot { get; }

        /// <summary>
        /// The login controller for this manager
        /// </summary>
        LoginViewModel LoginController { get; }

        /// <summary>
        /// The central routing function that handles basic initialization and login functionality of the manager
        /// </summary>
        void ManagerInitialize();

        /// <summary>
        /// Encapsulates the basic login functionality. See abstract class Manager for basic implementation
        /// </summary>
        bool Login();
    }
}