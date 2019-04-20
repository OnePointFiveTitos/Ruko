using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruko
{
    public class GeneralInfo : AccountItem<GeneralInfoModel>
    {
        public string ID
        {
            get => Model.id;
            set
            {
                if (Model.id != value)
                {
                    Model.id = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Status
        {
            get => Model.status;
            set
            {
                if (Model.status != value)
                {
                    Model.status = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Standing
        {
            get => Model.standing;
            set
            {
                if (Model.standing != value)
                {
                    Model.standing = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Lead
        {
            get => Model.lead;
            set
            {
                if (Model.lead != value)
                {
                    Model.lead = value;
                    OnPropertyChanged();
                }
            }
        }
        public GeneralInfo(Account parent, GeneralInfoModel model) : base(parent, model)
        {
        }
    }

    public class GeneralInfoModel : AccountItemModel
    {
        internal string id;
        internal string status;
        internal string standing;
        internal string lead;

        public GeneralInfoModel(string id, string status, string standing, string lead)
        {
            this.id = id;
            this.status = status;
            this.standing = standing;
            this.lead = lead;
        }
    }
}