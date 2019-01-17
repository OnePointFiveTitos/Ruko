using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Utilities.Functions;
using static Utilities.Regexes;
using Enums;
using MVVM;
using Managers;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows;

namespace Ruko
{
    public class RukoViewModel : ManagerViewModel<RukoWindow, RukoModel>
    {
        public static RukoViewModel Ruko { get; set; }
        public static GeneralViewModel GeneralViewModel => Ruko.General;
        public static SpecificViewModel SpecificViewModel => Ruko.Specific;

        public static void IterateCustomerSelectionStates(SelectionChangedEventArgs e, SelectionTypes type)
        {
            for (int i = 0; i < 2; i++)
            {
                bool isAdded = i == 0;
                foreach (CustomerViewModel customer in isAdded ? e.AddedItems : e.RemovedItems)
                {
                    customer.ToggleSelectionState(isAdded, type);
                }
            }
        }

        #region UI Control References
        public RukoView RukoView => Window.RukoView;

        public GeneralView GeneralView => RukoView.GeneralView;
        public DataGrid GeneralCustomersGrid => GeneralView.GeneralCustomersGrid;

        public SpecificView SpecificView => RukoView.SpecificView;
        public ListBox SpecificCustomersList => SpecificView.SpecificCustomersList;
        #endregion

        public NewCustomerViewModel NewCustomer
        {
            get => Model.newCustomer;
            set
            {
                if (Model.newCustomer != value)
                {
                    Model.newCustomer = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsAddingNewCustomer
        {
            get => Model.isAddingNewCustomer;
            set
            {
                if (Model.isAddingNewCustomer != value)
                {
                    Model.isAddingNewCustomer = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool ShowDebugOptions
        {
            get => Model.showDebugOptions;
            set
            {
                if (Model.showDebugOptions != value)
                {
                    Model.showDebugOptions = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool ShowGeneralCustomerControls
        {
            get => Model.showGeneralCustomerControls;
            set
            {
                if (Model.showGeneralCustomerControls != value)
                {
                    Model.showGeneralCustomerControls = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool ShowSpecificCustomerControls
        {
            get => Model.showSpecificCustomerControls;
            set
            {
                if (Model.showSpecificCustomerControls != value)
                {
                    Model.showSpecificCustomerControls = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(GeneralColumnWidth));
                    OnPropertyChanged(nameof(SpecificColumnWidth));
                }
            }
        }
        public bool ShowFullCustomerControls
        {
            get => Model.showFullCustomerControls;
            set
            {
                if (Model.showFullCustomerControls != value)
                {
                    Model.showFullCustomerControls = value;
                    if (value)
                    {
                        ShowGeneralCustomerControls = ShowSpecificCustomerControls = ShowSpecificCustomersList = true;
                    }
                    else
                    {
                        ShowGeneralCustomerControls = ShowSpecificCustomersList = false;
                    }
                    OnPropertyChanged();
                }
            }
        }
        public bool ShowSpecificCustomersList
        {
            get => Model.showSpecificCustomersList;
            set
            {
                if (Model.showSpecificCustomersList != value)
                {
                    Model.showSpecificCustomersList = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool ShowVisibilityToggleControls
        {
            get => Model.showVisibilityToggleControls;
            set
            {
                if (Model.showVisibilityToggleControls != value)
                {
                    Model.showVisibilityToggleControls = value;
                    OnPropertyChanged();
                }
            }
        }
        public GridLength GeneralColumnWidth => ShowSpecificCustomerControls ? GridLength.Auto : new GridLength(1, GridUnitType.Star);
        public GridLength SpecificColumnWidth => ShowSpecificCustomerControls ? new GridLength(1, GridUnitType.Star) : GridLength.Auto;
        public GeneralViewModel General
        {
            get => Model.general;
            set
            {
                if (Model.general != value)
                {
                    Model.general = value;
                    OnPropertyChanged();
                }
            }
        }
        public SpecificViewModel Specific
        {
            get => Model.specific;
            set
            {
                if (Model.specific != value)
                {
                    Model.specific = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand ExitCommand { get; private set; }

        public RukoViewModel(RukoWindow window, RukoModel model) : base(window, model, "Ruko")
        {
            Ruko = this;
            General = new GeneralViewModel(this, new GeneralModel());
            Specific = new SpecificViewModel(this, new SpecificModel());
        }

        public void Initialize()
        {
        }

        public override void InitializeCommands()
        {
            base.InitializeCommands();
            ExitCommand = new RelayCommand(() => Window.Close()); //TODO: check opened customer states
        }
    }

    public class RukoModel
    {
        internal NewCustomerViewModel newCustomer;
        internal bool isAddingNewCustomer = false;
        internal bool showDebugOptions = false;
        internal bool showGeneralCustomerControls = true;
        internal bool showSpecificCustomerControls = true;
        internal bool showSpecificCustomersList = true;
        internal bool showFullCustomerControls = true;
        internal bool showVisibilityToggleControls = true;
        internal GeneralViewModel general;
        internal SpecificViewModel specific;
    }
}