using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    public interface INodeControlViewModel<TParentViewModel, TControl, TModel> : INodeControlViewModel, INodeViewModel<TParentViewModel, TModel>, INodeViewModel
    {
        new TControl Control { get; set; }
    }
    public interface INodeControlViewModel
    {
        object Control { get; }
    }
}