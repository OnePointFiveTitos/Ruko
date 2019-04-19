namespace Ruko
{
    public abstract class AccountItem<TModel> : SectionItemBase<Account, TModel>, IAccountItem where TModel : AccountItemModel
    {
        public AccountItem(Account parent, TModel model) : base(parent, model)
        {
        }
    }

    public abstract class AccountItemModel : SectionItemBaseModel
    {

    }
}