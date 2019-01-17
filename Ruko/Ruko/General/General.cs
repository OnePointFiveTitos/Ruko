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
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows;

namespace Ruko
{
    public class GeneralViewModel : NodeViewModel<RukoViewModel, GeneralModel>
    {
        public GeneralView GeneralView => Parent.RukoView.GeneralView;
        public DataGrid GeneralCustomersGrid => GeneralView.GeneralCustomersGrid;

        public ObservableCollection<CustomerViewModel> GeneralCustomers { get; } = new ObservableCollection<CustomerViewModel>();
        public ObservableCollection<CustomerViewModel> SelectedGeneralCustomers { get; } = new ObservableCollection<CustomerViewModel>();
        //public int GeneralCustomersCount => GeneralCustomers.Count;
        //public int SelectedGeneralCustomersCount => SelectedGeneralCustomers.Count;
        private int gcc;
        public int GeneralCustomersCount
        {
            get => gcc;
            set
            {
                if (gcc != value)
                {
                    gcc = value;
                    OnPropertyChanged();
                }
            }
        }
        private int sgcc;
        public int SelectedGeneralCustomersCount
        {
            get => sgcc;
            set
            {
                if (sgcc != value)
                {
                    sgcc = value;
                    OnPropertyChanged();
                }
            }
        }
        //public List<CustomerViewModel> SGC { get; } = new List<CustomerViewModel>();
        public CustomerViewModel SelectedGeneralCustomer
        {
            get => Model.selectedGeneralCustomer ?? GeneralCustomers.FirstOrDefault();
            set
            {
                if (Model.selectedGeneralCustomer != value)
                {
                    Model.selectedGeneralCustomer = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool AreAllSelected
        {
            get => Model.areAllSelected;
            set
            {
                if (Model.areAllSelected != value)
                {
                    Model.areAllSelected = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand ToggleSelectionCommand { get; private set; }
        public ICommand DebugAddCommand { get; private set; }
        public ICommand OpenCommand { get; private set; }
        public ICommand OpenAllCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
        public ICommand EditCommand { get; private set; }

        public GeneralViewModel(RukoViewModel parent, GeneralModel model) : base(parent, model)
        {
            Initialize();
        }

        public void Initialize()
        {
            GeneralCustomers.CollectionChanged += (sender, e) =>
            {
                ReevaluateAreAllSelected();
                SelectedGeneralCustomer = SelectedGeneralCustomers.FirstOrDefault();
                GeneralCustomersCount = GeneralCustomers.Count;
            };
            SelectedGeneralCustomers.CollectionChanged += (sender, e) =>
            {
                SelectedGeneralCustomersCount = SelectedGeneralCustomers.Count;
            };
            DebugAddCommand.Execute("10");
        }

        public override void InitializeCommands()
        {
            base.InitializeCommands();
            ToggleSelectionCommand = new RelayCommand<bool>((isChecked) =>
            {
                foreach (CustomerViewModel customer in GeneralCustomers)
                {
                    customer.ToggleSelectionState(isChecked, SelectionTypes.General);
                }
            });
            DebugAddCommand = new RelayCommand<string>((count) =>
            {
                for (int i = 0; i < int.Parse(count); i++)
                {
                    AddCommand.Execute(null);
                }
            });
            AddCommand = new RelayCommand(() => GeneralCustomers.Add(new CustomerViewModel(Parent)));
            OpenCommand = new RelayCommand(() =>
            {
                if (SelectedGeneralCustomers.Count > 1)
                {
                    if (MessageBox.Show("Open all selected customer profiles?", "Confirm", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                    {
                        SelectedGeneralCustomers.ToList().ForEach(customer => customer.ToggleProfileState(true, true));
                    }
                }
                else
                {
                    SelectedGeneralCustomers.FirstOrDefault()?.ToggleProfileState(true, true);
                }
            });
            OpenAllCommand = new RelayCommand(() =>
            {
                if (MessageBox.Show("Open all profiles?", "Confirm", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    foreach (CustomerViewModel customer in GeneralCustomersGrid.Items.OfType<CustomerViewModel>())
                    {
                        customer.ToggleProfileState(true, true);
                    }
                }
            });
        }
        public void ReevaluateAreAllSelected()
        {
            AreAllSelected = SelectedGeneralCustomers.Count() == GeneralCustomersGrid.Items.Count;
        }
    }

    public class GeneralModel
    {
        internal CustomerViewModel selectedGeneralCustomer;
        internal bool areAllSelected = false;
    }
}