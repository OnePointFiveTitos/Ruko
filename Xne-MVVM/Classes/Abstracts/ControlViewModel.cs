namespace Xne_MVVM
{
    public abstract class ControlViewModel<TControl, TModel> : ViewModel<TModel>, IControl<TControl>
    {
        public TControl Control { get; }
        public ControlViewModel(TControl control, TModel model) : base(model)
        {
            Control = control;
        }
    }
}