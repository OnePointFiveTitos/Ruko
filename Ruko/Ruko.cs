using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Xne_MVVM;
using Xne_Utilities;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace Ruko
{
    public class RukoViewModel : ControlViewModel<MainWindow, RukoModel>, ICommander, IInitializer
    {
        public RukoView RukoView => Control.RukoView;

        #region Commands
        public Dictionary<string, ICommand> Commands { get; private set; }
        public ICommand ExitCommand => Commands["Exit"];
        #endregion

        public ObservableCollection<Customer> Customers { get; } = new ObservableCollection<Customer>();
        public Customer SelectedCustomer
        {
            get => Model.selectedCustomer;
            set
            {
                if (Model.selectedCustomer != value)
                {
                    Model.selectedCustomer = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsInitialized { get; set; }
        public bool IsPreInitialized { get; set; }
        public bool IsPostInitialized { get; set; }

        public event EventHandler PreInitialized;
        public event EventHandler Initialized;
        public event EventHandler PostInitialized;

        public RukoViewModel(MainWindow control, RukoModel model = null) : base(control, model ?? new RukoModel())
        {
            PreInitialize();
        }

        #region Initialization Stages
        public void PreInitialize()
        {
            PreInitialized += (Sender, e) => Initialize();
            Initialized += (sender, e) => PostInitialize();

            IsPreInitialized = true;
            PreInitialized?.Invoke(this, null);
        }

        public void Initialize()
        {
            InitializeCommands();

            IsInitialized = true;
            Initialized?.Invoke(this, null);
        }

        public void PostInitialize()
        {
            IsPostInitialized = true;
            PostInitialized?.Invoke(this, null);
        }
        #endregion

        public void InitializeCommands()
        {
            Commands = new Dictionary<string, ICommand>
            {
                ["Exit"] = new RelayCommand(Exit),
            };
        }

        #region Command methods
        public void Exit() => Control.Close();
        #endregion

    }

    public class RukoModel
    {
        internal Customer selectedCustomer;
    }
}