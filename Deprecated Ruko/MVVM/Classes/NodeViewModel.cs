using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    public abstract class NodeViewModel<TParentViewModel, TModel> : ViewModel<TModel>, INodeViewModel<TParentViewModel, TModel>, INodeViewModel, IViewModel<TModel>, IViewModel
    {
        public TParentViewModel Parent { get; set; }
        object INodeViewModel.Parent => Parent;
        public NodeViewModel(TParentViewModel parent, TModel model) 
            : base(model)
        {
            Parent = parent;
        }
    }
}