using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Ruko
{
    public class CustomerModel
    {
        internal OverviewModel overview;
        internal ContactModel contact;
        internal AccountModel account;
        internal ServiceModel service;
        internal OilModel oil;

        internal bool isOpened;
        internal bool isSelected;
        internal bool isOpenSelected;
        internal bool isEditing;
        internal bool isActive = true;
        internal bool isAdvancedView = false;

        internal int selectedInfoTabIndex = 0;
        internal TabItem selectedInfoTab;
        internal IMainInfo selectedInfo;

        public CustomerModel(OverviewModel overview, ContactModel contact, AccountModel account, ServiceModel service, OilModel oil)// : this(contact, account)
        {
            this.overview = overview;
            this.contact = contact;
            this.account = account;
            this.service = service;
            this.oil = oil;
        }
    }
}