using MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Management
{
    public abstract class ManagerViewModel<TWindow,TModel> : ControlViewModel<TWindow, TModel>, IManager
        where TWindow : Window
        where TModel : ManagerModel
    {
        public string AppName
        {
            get => Model.appName;
            set
            {
                if (Model.appName != value)
                {
                    Model.appName = value;
                    OnPropertyChanged();
                }
            }
        }
        public LoginViewModel<IManager> Login { get; }

        public ManagerViewModel(TWindow control, TModel model, LoginViewModel<IManager> login = null) : base(control, model)
        {
            AppName = GetType().Namespace;
            Login = login ?? new LoginViewModel<IManager>(this, new LoginWindow(), new LoginModel());

            if (!Login.IsValidated)
            {
                Control.Close();
            }
        }
    }

    public abstract class ManagerModel
    {
        internal string appName;
    }
}