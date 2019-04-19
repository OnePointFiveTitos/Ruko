namespace Ruko
{
    public abstract class OilItem<TModel> : SectionItemBase<Oil, TModel>, IOilItem where TModel : OilItemModel
    {
        public OilItem(Oil parent, TModel model) : base(parent, model)
        {
        }
    }

    public abstract class OilItemModel : SectionItemBaseModel
    {

    }
}