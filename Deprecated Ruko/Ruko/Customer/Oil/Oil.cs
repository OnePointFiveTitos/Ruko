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
namespace Ruko
{
    public class OilViewModel : TicketableInfoViewModel<OilModel, OilTicketViewModel>
    {
        public string Tank
        {
            get => Model.tank;
            set
            {
                if (Model.tank != value)
                {
                    Model.tank = value;
                    OnPropertyChanged();
                }
            }
        }
        public string FillLocation
        {
            get => Model.fillLocation;
            set
            {
                if (Model.fillLocation != value)
                {
                    Model.fillLocation = value;
                    OnPropertyChanged();
                }
            }
        }
        public string DeliveryInstructions
        {
            get => Model.deliveryInstructions;
            set
            {
                if (Model.deliveryInstructions != value)
                {
                    Model.deliveryInstructions = value;
                    OnPropertyChanged();
                }
            }
        }

        public OilViewModel(CustomerViewModel parent, OilModel model) : base(parent, model, "Oil")
        {
            //Model = Model ?? new OilModel();
        }
    }

    public class OilModel : TicketableInfoModel<OilTicketViewModel>
    {
        internal string tank;
        internal string fillLocation;
        internal string deliveryInstructions;
        public OilModel()
        {

        }
        public OilModel(string tank, string fillLocation, string deliveryInstructions)
        {
            this.tank = tank;
            this.fillLocation = fillLocation;
            this.deliveryInstructions = deliveryInstructions;
        }
    }
}