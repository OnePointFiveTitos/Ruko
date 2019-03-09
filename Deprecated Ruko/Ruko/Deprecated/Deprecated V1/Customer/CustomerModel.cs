using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruko
{
    public class CustomerModel
    {
        internal ContactViewModel contact;
        internal ServiceViewModel service;
        internal int selectedViewTabIndex = 0;
        internal bool isModifying = false;
        internal bool IsOpened = false;
        //public CustomerModel(ContactModel contact, ServiceModel service = null)
        //{
        //    this.contact = contact;
        //    this.service = service;
        //}
    }
}