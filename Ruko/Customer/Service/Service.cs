using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xne_MVVM;
using Xne_Utilities;
namespace Ruko
{
    public class Service : SectionBase<ServiceModel>
    {
        public HeatingSystem HeatingSystem => Model.heatingSystem;
        public ObservableCollection<ServiceTicket> Tickets => Model.tickets;
        public Service(Customer parent, ServiceModel model) : base(parent, model)
        {
        }
    }

    public class ServiceModel : SectionBaseModel
    {
        internal HeatingSystem heatingSystem;
        internal ObservableCollection<ServiceTicket> tickets;
        public ServiceModel(HeatingSystem heatingSystem, IEnumerable<ServiceTicket> tickets = null)
        {
            this.heatingSystem = heatingSystem;
            //this.tickets = tickets == null ? new ObservableCollection<ServiceTicket>() : new ObservableCollection<ServiceTicket>(tickets);
            this.tickets = new ObservableCollection<ServiceTicket>().Conditionialize(tickets);
        }
    }
}