namespace Ruko
{
    public abstract class ServiceItem<TModel> : SectionItemBase<Service, TModel>, IServiceItem where TModel : ServiceItemModel
    {
        public ServiceItem(Service parent, TModel model) : base(parent, model)
        {
        }
    }

    public abstract class ServiceItemModel : SectionItemBaseModel
    {

    }
}