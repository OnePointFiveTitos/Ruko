namespace MVVM
{
    public interface IViewModel<TModel> : IViewModel
    {
        new TModel Model { get; }
    }

    public interface IViewModel : ICommander
    {
        object Model { get; }
    }
}