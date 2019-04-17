using Xne_MVVM;

namespace Ruko
{
    public class Address : NodeViewModel<Customer, AddressModel>
    {
        public Address(Customer parent, AddressModel model) : base(parent, model)
        {
        }
    }

    public class AddressModel
    {

    }
}