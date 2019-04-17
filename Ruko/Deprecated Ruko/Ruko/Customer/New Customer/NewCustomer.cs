using MVVM;
using System.Windows.Input;
namespace Ruko
{
    public class NewCustomerViewModel : NodeViewModel<RukoViewModel, NewCustomerModel>
    {
        public CustomerViewModel NewCustomer
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

        public ICommand CreateCommand { get; private set; }
        public ICommand ResetCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        public NewCustomerViewModel(RukoViewModel parent, NewCustomerModel model) : base(parent, model)
        {
        }
    }

    public class NewCustomerModel
    {
        internal CustomerViewModel newCustomer;
    }
}