using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    public abstract class NodeViewModel<TParent, TModel> : ViewModel<TModel>, INode<TParent>
        where TParent : IViewModel
    {
        public TParent Parent { get; }
        object INode.Parent => Parent;

        public NodeViewModel(TParent parent, TModel model) : base(model)
        {
            Parent = parent;
        }
    }
}