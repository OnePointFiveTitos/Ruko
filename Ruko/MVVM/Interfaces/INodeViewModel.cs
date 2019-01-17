using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    public interface INodeViewModel<TParentViewModel, TModel> : INodeViewModel, IViewModel<TModel>, IViewModel
    {
        new TParentViewModel Parent { get; set; }
    }

    public interface INodeViewModel
    {
        object Parent { get; }
    }
}