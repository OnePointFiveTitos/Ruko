namespace Xne_MVVM
{
    public interface INode<out TParent>
    {
        TParent Parent { get; }
    }
}