namespace Ruko
{
    public class FinancialInfo : AccountItem<FinancialInfoModel>
    {
        public FinancialInfo(Account parent, FinancialInfoModel model) : base(parent, model)
        {
        }
    }

    public class FinancialInfoModel : AccountItemModel
    {

    }
}