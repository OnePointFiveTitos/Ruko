using MVVM;
namespace Ruko
{
    public class SystemUpdateViewModel : NodeViewModel<ServiceTicketViewModel, SystemUpdateModel>
    {
        public SystemUpdateViewModel(ServiceTicketViewModel parent, SystemUpdateModel model) : base(parent, model)
        {

        }
    }

    public class SystemUpdateModel
    {

    }
}