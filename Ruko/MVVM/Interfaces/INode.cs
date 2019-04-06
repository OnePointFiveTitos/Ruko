namespace MVVM
{
    public interface INode<TParent> : INode
        where TParent : IViewModel
    {
        new TParent Parent { get; }
    }

    public interface INode
    {
        object Parent { get; }
    }
}