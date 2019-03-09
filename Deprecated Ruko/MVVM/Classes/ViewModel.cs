using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    public abstract class ViewModel<TModel> : ObservableObject, IViewModel<TModel>, IViewModel
    {
        public TModel Model { get; set; }
        object IViewModel.Model => Model;
        public ViewModel(TModel model)
        {
            Model = model;
            OnPropertiesChanged();
            InitializeCommands();
        }
        /// <summary>
        /// Override this in the appropriate instance class and put the command initialization logic here
        /// </summary>
        public virtual void InitializeCommands() { }
    }
}