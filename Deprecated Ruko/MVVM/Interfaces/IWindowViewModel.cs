using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM
{
    public interface IWindowViewModel<TWindow, TModel> : IWindowViewModel, IViewModel<TModel>, IViewModel
    {
        new TWindow Window { get; set; }
    }
    public interface IWindowViewModel : IViewModel
    {
        object Window { get; }
    }
}