using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MVVM
{
    public abstract class HybridViewModel<TControl, TParent, TModel> : ControlViewModel<TControl, TModel>, INode<TParent>
        where TControl : Control
        where TParent : IViewModel
    {
        public TParent Parent { get; }
        object INode.Parent => Parent;

        public HybridViewModel(TControl control, TParent parent, TModel model) : base(control, model)
        {
            Parent = parent;
        }
    }
}