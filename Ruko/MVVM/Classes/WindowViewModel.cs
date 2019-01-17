using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM
{
    public abstract class WindowViewModel<TWindow, TModel> : ViewModel<TModel>, IWindowViewModel<TWindow, TModel>, IWindowViewModel, IViewModel<TModel>, IViewModel
    {
        public TWindow Window { get; set; }
        object IWindowViewModel.Window => Window;
        public WindowViewModel(TWindow window, TModel model) 
            : base (model)
        {
            Window = window;
        }
    }
}