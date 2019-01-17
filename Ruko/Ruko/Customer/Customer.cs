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
using System.Collections.ObjectModel;
using System.Windows;

namespace Ruko
{
    public class CustomerViewModel : NodeViewModel<RukoViewModel, CustomerModel>
    {
        public CustomerView CustomerView => Parent.SpecificView.CustomerView;
        public TabControl InfoTabs => CustomerView.InfoTabs;

        public ObservableCollection<CustomerViewModel> GeneralCustomers => Parent.General.GeneralCustomers;
        public ObservableCollection<CustomerViewModel> SpecificCustomers => Parent.Specific.SpecificCustomers;

        public AccountViewModel Account
        {
            get => Model.account;
            set
            {
                if (Model.account != value)
                {
                    Model.account = value;
                    OnPropertyChanged();
                }
            }
        }
        public ContactViewModel Contact
        {
            get => Model.contact;
            set
            {
                if (Model.contact != value)
                {
                    Model.contact = value;
                    OnPropertyChanged();
                }
            }
        }
        public ServiceViewModel Service
        {
            get => Model.service;
            set
            {
                if (Model.service != value)
                {
                    Model.service = value;
                    OnPropertyChanged();
                }
            }
        }
        public OilViewModel Oil
        {
            get => Model.oil;
            set
            {
                if (Model.oil != value)
                {
                    Model.oil = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsOpened
        {
            get => Model.isOpened;
            set
            {
                if (Model.isOpened != value)
                {
                    Model.isOpened = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsGeneralSelected
        {
            get => Model.isGeneralSelected;
            set
            {
                if (Model.isGeneralSelected != value)
                {
                    Model.isGeneralSelected = value;
                    if (value)
                    {
                        Parent.General.SelectedGeneralCustomers.Add(this);
                    }
                    else
                    {
                        Parent.General.SelectedGeneralCustomers.Remove(this);
                    }
                    OnPropertyChanged();
                    Parent.General.ReevaluateAreAllSelected();
                }
            }
        }
        public bool IsSpecificSelected
        {
            get => Model.isSpecificSelected;
            set
            {
                if (Model.isSpecificSelected != value)
                {
                    Model.isSpecificSelected = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsEditing
        {
            get => Model.isEditing;
            set
            {
                if (Model.isEditing != value)
                {
                    Model.isEditing = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsActive
        {
            get => Model.isActive;
            set
            {
                if (Model.isActive != value)
                {
                    Model.isActive = value;
                    OnPropertyChanged();
                }
            }
        }

        public int SelectedInfoTabIndex
        {
            get => Model.selectedInfoTabIndex;// < 0 ? 0 : Model.selectedInfoTabIndex;
            set
            {
                if (Model.selectedInfoTabIndex != value)
                {
                    Model.selectedInfoTabIndex = value;
                    SelectedInfoTab = InfoTabs.Items[value] as TabItem;
                    SelectedInfo = Infos[value];
                    OnPropertyChanged();
                }
            }
        }
        public TabItem SelectedInfoTab
        {
            get => Model.selectedInfoTab;
            set
            {
                if (Model.selectedInfoTab != value)
                {
                    Model.selectedInfoTab = value;
                    OnPropertyChanged();
                }
            }
        }
        public IInfo SelectedInfo
        {
            get => Model.selectedInfo;
            set
            {
                if (Model.selectedInfo != value)
                {
                    Model.selectedInfo = value;
                    OnPropertyChanged();
                }
            }
        }
        public IInfo[] Infos { get; }

        public ICommand ApplyCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand CloseCommand { get; private set; }
        public ICommand DeactivateCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        public CustomerViewModel(RukoViewModel parent, CustomerModel model = null) : base(parent, model)
        {
            Model = Model ?? new CustomerModel(this); //new CustomerModel(new AccountViewModel(this), new ContactViewModel(this), new ServiceViewModel(this), new OilViewModel(this));
            Infos = new IInfo[] { Account, Contact, Service, Oil };
        }

        public override void InitializeCommands()
        {
            base.InitializeCommands();
            //ApplyCommand = new RelayCommand(() => SelectedInfo?.ToggleEditingState(true));
            //CancelCommand = new RelayCommand(() => SelectedInfo?.ToggleEditingState(false));
            //EditCommand = new RelayCommand(() => SelectedInfo?.ToggleEditingState());
            ApplyCommand = new RelayCommand(() => IsEditing = false);
            CancelCommand = new RelayCommand(() => IsEditing = false);
            EditCommand = new RelayCommand(() => IsEditing = !IsEditing);
            CloseCommand = new RelayCommand(() => ToggleProfileState(false));
            DeactivateCommand = new RelayCommand(ToggleActivationState);
            DeleteCommand = new RelayCommand(Delete);
        }

        /// <summary>
        /// Selects or deselects the customer in the general and/or specific view
        /// </summary>
        /// <param name="isSelected">true if selecting; false if deselecting</param>
        /// <param name="type">the view to (de)select this customer in</param>
        public void ToggleSelectionState(bool isSelected, SelectionTypes type)
        {
            switch (type)
            {
                case SelectionTypes.General:
                    IsGeneralSelected = isSelected;
                    break;
                case SelectionTypes.Specific:
                    IsSpecificSelected = isSelected;
                    if (!IsOpened && IsSpecificSelected)
                    {
                        ToggleProfileState(true, true);
                    }
                    break;
            }
        }

        /// <summary>
        /// Opens or closes the customer profile
        /// </summary>
        /// <param name="isOpened">true if opening, false if closing</param>
        /// <param name="selectAfterOpen">selects/sets the SelectedOpenedCustomer to this customer</param>
        public void ToggleProfileState(bool isOpened, bool selectAfterOpen = false)
        {
            IsOpened = isOpened;
            if (IsOpened)
            {
                if (!SpecificCustomers.Contains(this))
                {
                    SpecificCustomers.Add(this);
                }

                if (selectAfterOpen && !IsSpecificSelected)
                {
                    ToggleSelectionState(true, SelectionTypes.Specific);
                    Parent.Specific.SelectedSpecificCustomer = this;
                }
            }
            else
            {
                if (IsEditing)
                {
                    MessageBoxResult result = MessageBox.Show($"{Contact?.Name.Full ?? "Debug Name"}'s profile is currently being edited. Do you want to close and save (Yes) or discard (No) changes, or Cancel and keep open?", "Confirm", MessageBoxButton.YesNoCancel);
                    if (result != MessageBoxResult.Cancel)
                    {
                        if (result == MessageBoxResult.Yes)
                        {
                            //TODO: implement save
                        }
                        IsEditing = false;
                        ToggleProfileState(false);
                    }
                    return;
                }

                SpecificCustomers.Remove(this);
                if (IsSpecificSelected)
                {
                    ToggleSelectionState(false, SelectionTypes.Specific);
                }
            }
        }

        /// <summary>
        /// Adds or Deletes the customer to/from the database
        /// </summary>
        /// <param name="isAdded">true if adding, false if deleting</param>
        public void TogglePersistenceState(bool isAdded)
        {
            if (isAdded)
            {
                GeneralCustomers.Add(this);
            }
            else
            {
                if (IsOpened)
                {
                    ToggleProfileState(false);
                }
                GeneralCustomers.Remove(this);
            }
        }

        /// <summary>
        /// Activates or Deactives the customer
        /// </summary>
        public void ToggleActivationState()
        {
            MessageBoxResult result = MessageBox.Show($"Do you wish to {string.Format("{0}",IsActive ? "deactivate" : "reactivate")} {Contact?.Name.Full ?? "Debug Name"}'s profile?", "Confirm", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    IsActive = IsActive ? false : true;
                    break;
                case MessageBoxResult.No:
                    IsActive = IsActive ? true : false;
                    break;
            }

            if (!IsActive && result == MessageBoxResult.Yes)
            {
                ToggleProfileState(false);
            }
        }

        /// <summary>
        /// Deletes the customer from the database permanently
        /// </summary>
        public void Delete()
        {
            if (IsActive)
            {
                ToggleActivationState();
            }

            if (!IsActive && MessageBox.Show($"Are you sure you want to delete {Contact?.Name.Full ?? "Debug Name"}'s profile from the database? WARNING: This is permanent and irreversible.", "Confirm Deletion", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                RemoveFromDatabase();
            }
        }

        /// <summary>
        /// Permanently removes the customer from the database
        /// </summary>
        public void RemoveFromDatabase()
        {
            if (SpecificCustomers.Contains(this))
            {
                SpecificCustomers.Remove(this);
            }
            GeneralCustomers.Remove(this);
        }

        /// <summary>
        /// (Re)evaluates the editing state for the customer whenever toggling the editing states of the Info's (Account, Contact, Service, Oil)
        /// </summary>
        public void ReevaluateEditingState()
        {
            foreach (IInfo info in Infos)
            {
                if (info.IsEditing)
                {
                    IsEditing = true;
                    return;
                }
            }
            IsEditing = false;
        }

        /// <summary>
        /// Resets the editing state of the entire customer
        /// </summary>
        /// <param name="isEditing">The value to set everything to</param>
        public void ResetEditingState(bool isEditing)
        {
            foreach (IInfo info in Infos)
            {
                info.IsEditing = isEditing;
            }
            IsEditing = isEditing;
        }
    }

    public class CustomerModel
    {
        internal AccountViewModel account;
        internal ContactViewModel contact;
        internal ServiceViewModel service;
        internal OilViewModel oil;

        internal bool isOpened = false;
        internal bool isGeneralSelected = false;
        internal bool isSpecificSelected = false;
        internal bool isEditing = false;
        internal bool isActive = true;

        internal int selectedInfoTabIndex = 0;
        internal TabItem selectedInfoTab;
        internal IInfo selectedInfo;

        public CustomerModel(CustomerViewModel customer)
        {
            account = new AccountViewModel(customer, new AccountModel());
            contact = new ContactViewModel(customer, new ContactModel());
            service = new ServiceViewModel(customer, new ServiceModel());
            oil = new OilViewModel(customer, new OilModel());
        }

        public CustomerModel(AccountViewModel account, ContactViewModel contact, ServiceViewModel service, OilViewModel oil)
        {
            this.account = account;
            this.contact = contact;
            this.service = service;
            this.oil = oil;
        }
    }
}