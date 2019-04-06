using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    public abstract class ViewModel<TModel> : ObservableObject, IViewModel<TModel>
    {
        public TModel Model { get; set; }
        object IViewModel.Model => Model;

        public ViewModel(TModel model)
        {
            Model = model;
            InitializeCommands();
        }

        public virtual void InitializeCommands() { }
    }
}