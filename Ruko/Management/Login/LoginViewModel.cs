using MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Management
{
    //used for just login testing
    public class LoginViewModel : ControlViewModel<LoginWindow, LoginModel>
    {
        public LoginView LoginView => Control.LoginView;
        public TextBox PasswordBox => LoginView.PasswordBox;

        public string Title
        {
            get => Model.title;
            set
            {
                if (Model.title != value)
                {
                    Model.title = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Username
        {
            get => Model.username;
            set
            {
                if (Model.username != value)
                {
                    Model.username = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Password
        {
            get => Model.password;
            set
            {
                if (Model.password != value)
                {
                    Model.password = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsBypassable
        {
            get => Model.isBypassable;
            set
            {
                if (Model.isBypassable != value)
                {
                    Model.isBypassable = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsValidated
        {
            get => Model.isValidated;
            set
            {
                if (Model.isValidated != value)
                {
                    Model.isValidated = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand LoginCommand { get; private set; }

        public LoginViewModel(LoginWindow control, LoginModel model, string title = "App Login") : base(control, model)
        {
            Title = title;
        }

        public override void InitializeCommands()
        {
            LoginCommand = new RelayCommand(Validate);
        }

        public override void InitializeControls()
        {
            PasswordBox.KeyDown += (sender, e) =>
            {
                if (e.Key == Key.Enter)
                {
                    Validate();
                }
            };
        }

        public virtual void Validate()
        {
            IsValidated = true;
            Control.Close();
        }
    }

    //used in conjunction with a manager
    public class LoginViewModel<TManager> : LoginViewModel
        where TManager : IManager
    {
        public IManager Manager { get; }

        public LoginViewModel(IManager manager, LoginWindow control, LoginModel model) : base(new LoginWindow(), model, $"{manager.AppName} Login")
        {
            Manager = manager;
            Control.DataContext = this;

            if (!IsBypassable)
            {
                Control.ShowDialog();
            }
        }
    }

    public class LoginModel
    {
        internal string title;
        internal string username;
        internal string password;
        internal bool isBypassable;
        internal bool isValidated = false;

        public LoginModel(bool isBypassable = false)
        {
            this.isBypassable = isBypassable;
        }
    }
}