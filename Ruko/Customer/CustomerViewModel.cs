namespace Ruko
{
    public class CustomerViewModel : InformationViewModel
    {
        private Customer model;

        public Contact Contact
        {
            get => model.contact;
            set
            {
                if (model.contact != value)
                {
                    model.contact = value;
                    OnPropertyChanged();
                }
            }
        }

        public CustomerViewModel(Customer model = null)
        {
            this.model = model ?? new Customer();
        }
    }
}