using MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static Utilities.Functions;

namespace Login
{
    public class LoginViewModel : WindowViewModel<LoginWindow, LoginModel>
    {
        /// <summary>
        /// The title for the LoginWindow
        /// </summary>
        public string WindowTitle
        {
            get => Model.windowTitle;
            set
            {
                if (Model.windowTitle != value)
                {
                    Model.windowTitle = value;
                    OnPropertyChanged();
                }
            }
        }
        /// <summary>
        /// The title/header that displays above the LoginControl
        /// </summary>
        public string DisplayTitle
        {
            get => Model.displayTitle;
            set
            {
                if (Model.displayTitle != value)
                {
                    Model.displayTitle = value;
                    OnPropertyChanged();
                }
            }
        }
        /// <summary>
        /// Toggles login bypassing, not sure if ill make this use editable or not
        /// </summary>
        public bool IsLoginBypassable { get; }
        /// <summary>
        /// Encapsulates the state of the login validation. IsLoginBypassable will override this to true if bypass is enabled
        /// </summary>
        public bool IsLoginValidated
        {
            get => IsLoginBypassable ? true : Model.isLoginValidated;
            set
            {
                if (Model.isLoginValidated != value)
                {
                    Model.isLoginValidated = value;
                    OnPropertyChanged();
                }
            }
        }
        /// <summary>
        /// User entered username, this is really just a placeholder right now
        /// </summary>
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
        /// <summary>
        /// Reference to the passwordbox in the login control
        /// </summary>
        public PasswordBox PasswordBox => Window.LoginView.LoginControl.PasswordBox;
        /// <summary>
        /// Encapsulates any error or notification text relevant to the user's most recent action
        /// </summary>
        public string Error
        {
            get => Model.error;
            set
            {
                if (Model.error != value)
                {
                    Model.error = value;
                    OnPropertyChanged();
                }
            }
        }
        /// <summary>
        /// Binds to the "Login" button on the LoginControl
        /// </summary>
        public ICommand LoginCommand => new RelayCommand<LoginViewModel>(ValidateLogin);
        public LoginViewModel(string windowTitle, string displayTitle, bool isLoginBypassable = false, LoginWindow window = null, LoginModel model = null) : base(window, model)
        {
            Window = ReturnIfNotNull(window, new LoginWindow() { DataContext = this });
            Model = ReturnIfNotNull(model, new LoginModel());

            IsLoginBypassable = isLoginBypassable;

            WindowTitle = ReturnIfNotNEW(WindowTitle, windowTitle);
            DisplayTitle = ReturnIfNotNEW(DisplayTitle, displayTitle);

            PasswordBox.KeyDown += PasswordBox_KeyDown;
        }

        /// <summary>
        /// Validates the login (This is WIP and must be changed later); Subesquently closes the window on valid login (whether its bypassable or actually validated)
        /// </summary>
        public void ValidateLogin(LoginViewModel loginViewModel)
        {
            if (!IsLoginBypassable)
            {
                string username = loginViewModel.Username;
                string password = loginViewModel.PasswordBox.Password;
                if (AtLeastOneIsNotNEW(username,password))
                {
                    foreach (string value in ReturnAllNonNEW(username, password))
                    {
                        MessageBox.Show(value);
                    }
                }
                IsLoginValidated = true;
            }

            if (IsLoginValidated)
            {
                Window.Close();
            }
        }

        /// <summary>
        /// Initiates the login process and opens the login window;
        /// </summary>
        public bool InitiateLogin()
        {
            if (!IsLoginBypassable)
            {
                Window.ShowDialog();
            }

            return IsLoginValidated;
        }

        public void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ValidateLogin(this);
            }
        }
    }
}