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
    public class Oil : SectionBase<OilModel>
    {
        public ObservableCollection<OilTicket> Tickets => Model.tickets;
        public Oil(Customer parent, OilModel model) : base(parent, model)
        {
        }
    }

    public class OilModel : SectionBaseModel
    {
        internal ObservableCollection<OilTicket> tickets;
        public OilModel(IEnumerable<OilTicket> tickets = null)
        {
            //this.tickets = tickets == null ? new ObservableCollection<OilTicket>() : new ObservableCollection<OilTicket>(tickets);
            this.tickets = new ObservableCollection<OilTicket>().Conditionialize(tickets);
        }
    }
}