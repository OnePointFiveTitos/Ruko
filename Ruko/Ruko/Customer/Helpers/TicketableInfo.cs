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

namespace Ruko
{
    public abstract class TicketableInfoViewModel<TModel,TTicket> : InfoViewModel<TModel>
        where TModel : TicketableInfoModel<TTicket>
        where TTicket : class, ITicket
    {
        public ObservableCollection<TTicket> Tickets { get; } = new ObservableCollection<TTicket>();
        public TTicket SelectedTicket
        {
            get => Model.selectedTicket;
            set
            {
                if (Model.selectedTicket != value)
                {
                    Model.selectedTicket = value;
                    OnPropertyChanged();
                }
            }
        }
        public TTicket SelectedOpenedTicket
        {
            get => Model.selectedOpenedTicket;
            set
            {
                if (Model.selectedOpenedTicket != value)
                {
                    Model.selectedOpenedTicket = value;
                    OnPropertyChanged();
                }
            }
        }

        public TicketableInfoViewModel(CustomerViewModel parent, TModel model, string infoName) : base(parent, model, infoName)
        {
        }
    }

    public abstract class TicketableInfoModel<TTicket> : InfoModel
        where TTicket : class, ITicket
    {
        internal TTicket selectedTicket;
        internal TTicket selectedOpenedTicket;
    }
}