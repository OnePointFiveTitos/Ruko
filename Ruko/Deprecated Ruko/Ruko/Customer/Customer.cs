using System.Linq;
using MVVM;
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

        public GeneralViewModel General => Parent.General;
        public SpecificViewModel Specific => Parent.Specific;
        public ObservableCollection<CustomerViewModel> GeneralCustomers => General.Customers;
        public ObservableCollection<CustomerViewModel> SpecificCustomers => Specific.Customers;

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
                        Parent.General.SelectedCustomers.Add(this);
                    }
                    else
                    {
                        Parent.General.SelectedCustomers.Remove(this);
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

        public bool IsEdited
        {
            get => Model.isEdited;
            set
            {
                if (Model.isEdited != value)
                {
                    Model.isEdited = value;
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
        public ICommand ActivateCommand { get; private set; }
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
            ApplyCommand = new RelayCommand(Save);
            CancelCommand = new RelayCommand(View);
            EditCommand = new RelayCommand(Edit);
            CloseCommand = new RelayCommand(Close);
            ActivateCommand = new RelayCommand(Activate);
            DeactivateCommand = new RelayCommand(Deactivate);
            DeleteCommand = new RelayCommand(Delete);
        }

        #region Old
        ///// <summary>
        ///// Selects or deselects the customer in the general and/or specific view
        ///// </summary>
        ///// <param name="isSelected">true if selecting; false if deselecting</param>
        ///// <param name="type">the view to (de)select this customer in</param>
        //public void ToggleSelectionState(bool isSelected, SelectionTypes type)
        //{
        //    switch (type)
        //    {
        //        case SelectionTypes.General:
        //            IsGeneralSelected = isSelected;
        //            break;
        //        case SelectionTypes.Specific:
        //            IsSpecificSelected = isSelected;
        //            if (!IsOpened && IsSpecificSelected)
        //            {
        //                ToggleProfileState(true, true);
        //            }
        //            break;
        //    }
        //}
        ///// <summary>
        ///// Opens or closes the customer profile
        ///// </summary>
        ///// <param name="isOpened">true if opening, false if closing</param>
        ///// <param name="selectAfterOpen">selects/sets the SelectedOpenedCustomer to this customer</param>
        //public void ToggleProfileState(bool isOpened, bool selectAfterOpen = false)
        //{
        //    IsOpened = isOpened;
        //    if (IsOpened)
        //    {
        //        if (!SpecificCustomers.Contains(this))
        //        {
        //            SpecificCustomers.Add(this);
        //        }

        //        if (selectAfterOpen && !IsSpecificSelected)
        //        {
        //            ToggleSelectionState(true, SelectionTypes.Specific);
        //            Specific.SelectedCustomer = this;
        //        }
        //    }
        //    else
        //    {
        //        if (IsEditing)
        //        {
        //            MessageBoxResult result = MessageBox.Show($"{Contact?.Name?.Full ?? "Debug Name"}'s profile is currently being edited. Do you want to close and save (Yes) or discard (No) changes, or Cancel and keep open?", "Confirm", MessageBoxButton.YesNoCancel);
        //            if (result != MessageBoxResult.Cancel)
        //            {
        //                if (result == MessageBoxResult.Yes)
        //                {
        //                    //TODO: implement save
        //                }
        //                IsEditing = false;
        //                ToggleProfileState(false);
        //            }
        //            return;
        //        }

        //        SpecificCustomers.Remove(this);
        //        if (IsSpecificSelected)
        //        {
        //            ToggleSelectionState(false, SelectionTypes.Specific);
        //        }
        //    }
        //}
        ///// <summary>
        ///// Adds or Deletes the customer to/from the database
        ///// </summary>
        ///// <param name="isAdded">true if adding, false if deleting</param>
        //public void TogglePersistenceState(bool isAdded)
        //{
        //    if (isAdded)
        //    {
        //        GeneralCustomers.Add(this);
        //    }
        //    else
        //    {
        //        if (IsOpened)
        //        {
        //            ToggleProfileState(false);
        //        }
        //        GeneralCustomers.Remove(this);
        //    }
        //}
        ///// <summary>
        ///// Activates or Deactives the customer
        ///// </summary>
        //public void ToggleActivationState()
        //{
        //    MessageBoxResult result = MessageBox.Show($"Do you wish to {string.Format("{0}",IsActive ? "deactivate" : "reactivate")} {Contact?.Name?.Full ?? "Debug Name"}'s profile?", "Confirm", MessageBoxButton.YesNo);
        //    switch (result)
        //    {
        //        case MessageBoxResult.Yes:
        //            IsActive = IsActive ? false : true;
        //            break;
        //        case MessageBoxResult.No:
        //            IsActive = IsActive ? true : false;
        //            break;
        //    }

        //    if (!IsActive && result == MessageBoxResult.Yes)
        //    {
        //        if (IsEditing)
        //        {

        //        }
        //        else
        //        {
        //            ToggleProfileState(false);
        //        }
        //    }
        //}
        ///// <summary>
        ///// Deletes the customer from the database permanently
        ///// </summary>
        ////public void Delete()
        ////{
        ////    if (IsActive)
        ////    {
        ////        ToggleActivationState();
        ////    }

        ////    if (!IsActive && MessageBox.Show($"Are you sure you want to delete {Contact?.Name?.Full ?? "Debug Name"}'s profile from the database? WARNING: This is permanent and irreversible.", "Confirm Deletion", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
        ////    {
        ////        RemoveFromDatabase();
        ////    }
        ////}
        ///// <summary>
        ///// Permanently removes the customer from the database
        ///// </summary>
        //public void RemoveFromDatabase()
        //{
        //    if (SpecificCustomers.Contains(this))
        //    {
        //        SpecificCustomers.Remove(this);
        //    }
        //    GeneralCustomers.Remove(this);
        ////}
        //public void ToggleActiveState(bool isActive)
        //{
        //    MessageBoxResult result = Confirm($"Do you wish to {string.Format("{0}", IsActive ? "deactivate" : "reactivate")} {Contact?.Name?.Full ?? "Debug Name"}'s profile?", MessageBoxButton.YesNo);
        //    if (result == MessageBoxResult.Yes)
        //    {

        //    }
        //    else
        //    {

        //    }

        //    if (!isActive)
        //    {
        //        if (IsOpened)
        //        {
        //            Close();
        //            if (!IsOpened)
        //            {
        //                IsActive = false;
        //            }
        //        }
        //    }

        //    IsActive = IsActive;
        //}
        //public void Select(SelectionTypes type)
        //{
        //    if (type == SelectionTypes.General)
        //    {
        //        IsGeneralSelected = true;
        //    }
        //    else
        //    {
        //        IsSpecificSelected = true;
        //    }
        //}
        //public void Unselect(SelectionTypes type)
        //{
        //    if (type == SelectionTypes.General)
        //    {
        //        IsGeneralSelected = false;
        //    }
        //    else
        //    {
        //        IsSpecificSelected = false;
        //    }
        //}
        #endregion

        ///// <summary>
        ///// (Re)evaluates the editing state for the customer whenever toggling the editing states of the Info's (Account, Contact, Service, Oil)
        ///// </summary>
        //public void ReevaluateEditingState()
        //{
        //    foreach (IInfo info in Infos)
        //    {
        //        if (info.IsEditing)
        //        {
        //            IsEditing = true;
        //            return;
        //        }
        //    }
        //    IsEditing = false;
        //}
        ///// <summary>
        ///// Resets the editing state of the entire customer
        ///// </summary>
        ///// <param name="isEditing">The value to set everything to</param>
        //public void ResetEditingState(bool isEditing)
        //{
        //    foreach (IInfo info in Infos)
        //    {
        //        info.IsEditing = isEditing;
        //    }
        //    IsEditing = isEditing;
        //}

        public void ToggleSelectState(bool isSelected, SelectionTypes type, ICustomersContainer container)
        {
            container.SelectedCustomer = isSelected
                ? this
                : type == SelectionTypes.General
                ? General.SelectedCustomers.FirstOrDefault()
                : Specific.Customers.FirstOrDefault();

            switch (type)
            {
                case SelectionTypes.General:
                    IsGeneralSelected = isSelected;
                    break;
                case SelectionTypes.Specific:
                    IsSpecificSelected = isSelected;
                    break;
            }
        }

        public void Open(bool selectAfterOpen)
        {
            if (!SpecificCustomers.Contains(this))
            {
                SpecificCustomers.Add(this);
                IsOpened = true;
                if (selectAfterOpen)
                {
                    Specific.SelectedCustomer = this;
                }
            }
        }

        public void Close()
        {
            if (IsEditing)
            {
                View();
            }

            if (!IsEditing)
            {
                SpecificCustomers.Remove(this);
                IsOpened = false;
            }
        }

        public void Save()
        {
            //TODO: implement saving
            View();
        }

        public void Edit()
        {
            if (!IsActive)
            {
                Activate();
            }

            if (IsActive)
            {
                Open(true);
                IsEditing = true;
            }
        }

        public void View()
        {
            if (IsEdited)
            {
                MessageBoxResult result = Confirm($"{Contact?.Name?.Full ?? "Debug Name"}'s profile is currently being edited. Do you want to close and save (Yes) or discard (No) changes, or Cancel and keep open?", MessageBoxButton.YesNoCancel);
                if (result != MessageBoxResult.Cancel)
                {
                    if (result == MessageBoxResult.Yes)
                    {
                        Save();
                    }
                    IsEditing = false;
                }
                return;
            }
            IsEditing = false;
        }

        public void Activate()
        {
            IsActive = Confirm($"Do you wish to reactivate {Contact?.Name?.Full ?? "Debug Name"}'s profile?", MessageBoxButton.YesNo) == MessageBoxResult.Yes;
        }

        public void Deactivate()
        {
            if (IsOpened && Confirm($"Do you wish to deactivate {Contact?.Name?.Full ?? "Debug Name"}'s profile?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Close();
            }

            if (!IsOpened)
            {
                IsActive = false;
            }
        }

        public void Add()
        {
            if (!GeneralCustomers.Contains(this))
            {
                GeneralCustomers.Add(this);
            }
        }

        public void Delete()
        {
            if (IsOpened)
            {
                Close();
            }

            if (!IsOpened && IsActive)
            {
                Deactivate();
            }

            if (!IsActive && Confirm($"Are you sure you want to delete {Contact?.Name?.Full ?? "Debug Name"}'s profile from the database? WARNING: This is permanent and irreversible.", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                GeneralCustomers.Remove(this);
            }
        }

        public MessageBoxResult Confirm(string message, MessageBoxButton button)
            => MessageBox.Show(message, "Confirm", button);

        //public void SelectStateToggle(bool isSelected, SelectionTypes type)
        //{
        //    switch (type)
        //    {
        //        case SelectionTypes.General:
        //            IsGeneralSelected = isSelected;
        //            break;
        //        case SelectionTypes.Specific:
        //            IsSpecificSelected = isSelected;
        //            if (isSelected)
        //            {
        //                ProfileStateToggle(isSelected);
        //            }
        //            break;
        //    }
        //}
        //public void ProfileStateToggle(bool isOpened)
        //{
        //    if (isOpened)
        //    {
        //        AddToSpecific();
        //    }
        //    else
        //    {
        //        RemoveFromSpecific();
        //    }

        //    IsOpened = isOpened;
        //}
        //public void ActiveStateToggle(bool isActive)
        //{
        //    if (!isActive)
        //    {
        //    }

        //    IsActive = !IsActive;
        //}
        //public void EditStateToggle(bool isEditing)
        //{
        //    //TODO: check for changes/edits - if there are any then ask user to save or discard or cancel
        //    IsEditing = !IsEditing;
        //}
        //public void PersistenceStateToggle(bool isAdded)
        //{
        //    if (isAdded)
        //    {
        //        GeneralCustomers.Add(this);
        //    }
        //    else
        //    {
        //        RemoveFromGeneral();
        //    }
        //}
        //public void AddToSpecific()
        //{
        //    if (!SpecificCustomers.Contains(this))
        //    {
        //        SpecificCustomers.Add(this);
        //    }
        //}
        //public void RemoveFromSpecific()
        //{
        //    if (IsEditing)
        //    {
        //        EditStateToggle(false);
        //        if (!IsEditing)
        //        {
        //            SpecificCustomers.Remove(this);
        //            ProfileStateToggle(false);
        //        }
        //    }
        //}
        //public void RemoveFromGeneral()
        //{
        //    if (IsOpened)
        //    {
        //        RemoveFromSpecific();
        //        if (!IsOpened && IsActive)
        //        {
        //            ActiveStateToggle(false);
        //            if (!IsActive)
        //            {
        //                GeneralCustomers.Remove(this);
        //            }
        //        }
        //    }
        //}
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

        internal bool isEdited = false;

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