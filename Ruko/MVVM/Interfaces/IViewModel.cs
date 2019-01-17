using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    public interface IViewModel<TModel> : IViewModel
    {
        new TModel Model { get; set; }
    }
    public interface IViewModel
    {
        object Model { get; }
    }
}