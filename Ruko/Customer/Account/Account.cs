using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xne_MVVM;

namespace Ruko
{
    public class Account : SectionBase<AccountModel>
    {
        public GeneralInfo GeneralInfo => Model.generalInfo;
        public FinancialInfo FinancialInfo => Model.financialInfo;

        public Account(Customer parent, AccountModel model) : base(parent, model)
        {
        }
    }

    public class AccountModel : SectionBaseModel
    {
        internal GeneralInfo generalInfo;
        internal FinancialInfo financialInfo;

        public AccountModel(GeneralInfo generalInfo, FinancialInfo financialInfo)
        {
            this.generalInfo = generalInfo;
            this.financialInfo = financialInfo;
        }
    }
}