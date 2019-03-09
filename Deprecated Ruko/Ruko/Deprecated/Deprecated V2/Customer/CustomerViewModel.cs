using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Enums;
using MVVM;
using static Utilities.Functions;

namespace Ruko
{
    public class CustomerViewModel : NodeViewModel<RukoViewModel, CustomerModel>
    {
        //public static CustomerViewModel CreateEmptyCustomer() 
        //    => new CustomerViewModel(RukoViewModel.Ruko, new CustomerModel(new OverviewModel(), new ContactModel(), new AccountModel(), new ServiceModel(), new OilModel()));

        #region Controls
        public CustomerView CustomerView => Parent.CustomerView;
        public TabControl InfoTabs => CustomerView?.InfoTabs;
        #endregion

        public ICommand CloseCommand { get; private set; }
        public ICommand DeactivateCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        public OverviewViewModel Overview { get; private set; }
        public ContactViewModel Contact { get; private set; }
        public AccountViewModel Account { get; private set; }
        public ServiceViewModel Service { get; private set; }
        public OilViewModel Oil { get; private set; }

        IMainInfo[] Infos { get; }

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
        public bool IsSelected
        {
            get => Model.isSelected;
            set
            {
                if (Model.isSelected != value)
                {
                    Model.isSelected = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsOpenSelected
        {
            get => Model.isOpenSelected;
            set
            {
                if (Model.isOpenSelected != value)
                {
                    Model.isOpenSelected = value;
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
        public bool IsAdvancedView
        {
            get => Model.isAdvancedView;
            set
            {
                if (Model.isAdvancedView != value)
                {
                    Model.isAdvancedView = value;
                    OnPropertyChanged();
                }
            }
        }
        public int SelectedInfoTabIndex
        {
            get => Model.selectedInfoTabIndex;
            set
            {
                if (Model.selectedInfoTabIndex != value)
                {
                    Model.selectedInfoTabIndex = value;
                    OnPropertyChanged();
                    SelectedInfoTab = InfoTabs.SelectedItem as TabItem;
                    SelectedInfo = Infos[value];
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
        public IMainInfo SelectedInfo
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

        public CustomerViewModel(RukoViewModel parent, CustomerModel model) : base(parent, model)
        {
            Overview = new OverviewViewModel(this, model.overview);
            Contact = new ContactViewModel(this, model.contact);
            Account = new AccountViewModel(this, model.account);
            Service = new ServiceViewModel(this, model.service);
            Oil = new OilViewModel(this, model.oil);
            Infos = new IMainInfo[] { Overview, Contact, Account, Service, Oil };
            SelectedInfo = Infos[SelectedInfoTabIndex];
            //if (IsNEW(Account.ID))
            //{
            //    AccountViewModel.GenerateNewID(this);
            //}
        }

        public override void InitializeCommands()
        {
            CloseCommand = new RelayCommand(Close);
            DeactivateCommand = new RelayCommand(ToggleActivation);
            DeleteCommand = new RelayCommand(Delete);
        }

        public void Open()
        {
            if (!Parent.OpenedCustomers.Contains(this))
            {
                Parent.OpenedCustomers.Add(this);
            }
            IsOpened = true;
        }
        public void Close()
        {
            if (IsEditing)
            {
                MessageBoxResult result = MessageBox.Show($"{Contact.Name}'s profile is currently being edited. Save (Yes) OR Discard (No), any changes and close, OR Cancel and keep open?", "Confirm Close", MessageBoxButton.YesNoCancel);
                //yes - save changes and close profile
                //no - discard changes and close profile
                //cancel - disregard close action and keep profile open
                if (result != MessageBoxResult.Cancel)
                {
                    if (result == MessageBoxResult.Yes)
                    {
                        //implement logic for saving changes here
                    }
                    RemoveFromOpenedCustomers();
                    ResetCustomerEditingState(false);
                }
            }
            else
            {
                RemoveFromOpenedCustomers();
            }
        }
        public void RemoveFromOpenedCustomers()
        {
            if (Parent.OpenedCustomers.Contains(this))
            {
                Parent.OpenedCustomers.Remove(this);
            }
            IsOpened = false;
        }
        public void Add()
        {
            Parent.Customers.Add(this);
            AccountViewModel.GenerateNewID(this);
        }
        public void Delete()
        {
            if (IsEditing)
            {
                Close();
                if (IsEditing)
                {
                    return;
                }
            }
            else
            {
                //if its active then deactive it (double check)
                if (IsActive)
                {
                    ToggleActivation();
                    //if it is then set inactive then check if you want to remove from customers, else disregard
                    if (!IsActive)
                    {
                        RemoveFromCustomers();
                    }
                }
                else
                {
                    RemoveFromCustomers();
                }
            }
        }
        public void RemoveFromCustomers()
        {
            //TODO: add extra validation and encipherment key check here when that is also implemented
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this customer from the database?\nThis is irreversible (seriously).", "Confirm Deletion", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                AccountViewModel.ResetID(this);
                Parent.Customers.Remove(this);
                Parent.OpenedCustomers.Remove(this);
            }
            else
            {
                IsActive = true;
            }
        }
        public void ToggleActivation()
        {
            if (IsActive)
            {
                MessageBoxResult result = MessageBox.Show("Confirm deactivation of customer profile?", "Confirm Deactivation", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    IsActive = false;
                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Confirm reactivation of customer profile?", "Confirm Reactivation", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    IsActive = true;
                }
            }
        }
        public void Edit(int infoTabIndex) => Infos[infoTabIndex].Edit(infoTabIndex);
        //not sure if im going to use the selection functions
        public void Select() //not sure if i need this function
        {
            if (!IsSelected)
            {
                Parent.SelectedCustomer = this;
                IsSelected = true;
            }
        }
        public void Deselect()
        {
            Parent.SelectedCustomer = Parent.Customers.FirstOrDefault();
            IsSelected = false;
        }
        public void SelectOpened()
        {
            Parent.SelectedOpenedCustomer = this;
            IsOpenSelected = true;
        }
        public void DeselectOpened()
        {
            Parent.SelectedOpenedCustomer = Parent.OpenedCustomers.FirstOrDefault();
            IsOpenSelected = false;
        }
        public void EvaluateEditingState()
        {
            foreach (IMainInfo info in Infos)
            {
                if (info.IsEditing)
                {
                    IsEditing = true;
                    return;
                }
            }
            IsEditing = false;
        }
        public void ResetCustomerEditingState(bool state)
        {
            foreach (IMainInfo info in Infos)
            {
                info.IsEditing = state;
            }
            IsEditing = state;
        }
        public void Save()
        {

        }
    }
}