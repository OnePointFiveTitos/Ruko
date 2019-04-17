namespace Xne_MVVM
{
    public abstract class NodeViewModel<TParent, TModel> : ViewModel<TModel>, INode<TParent>
    {
        public TParent Parent { get; }
        public NodeViewModel(TParent parent, TModel model) : base(model)
        {
            Parent = parent;
        }
    }
}