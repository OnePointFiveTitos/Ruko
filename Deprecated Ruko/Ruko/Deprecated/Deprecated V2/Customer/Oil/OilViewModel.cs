using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM;

namespace Ruko
{
    public class OilViewModel : MainInfoViewModel<OilModel>
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
        public string CrossStreet => Parent.Contact.Address.CrossStreet;
        public OilViewModel(CustomerViewModel parent, OilModel model) : base(parent, model)
        {
        }
    }
}