using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static Utilities.Functions;

namespace MVVM
{
    public abstract class NodeControlViewModel<TParentViewModel, TControl, TModel> : NodeViewModel<TParentViewModel, TModel>, INodeControlViewModel<TParentViewModel, TControl, TModel>, INodeControlViewModel, INodeViewModel<TParentViewModel, TModel>, INodeViewModel, IViewModel<TModel>, IViewModel
    {
        public TControl Control { get; set; }
        object INodeControlViewModel.Control => Control;

        public NodeControlViewModel(TParentViewModel parent, TControl control, TModel model) 
            : base(parent, model)
        {
            Control = control;
        }
    }
}