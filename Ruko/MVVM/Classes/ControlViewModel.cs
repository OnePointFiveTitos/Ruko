using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MVVM
{
    public abstract class ControlViewModel<TControl, TModel> : ViewModel<TModel>, IControl<TControl>
        where TControl : Control
    {
        public TControl Control { get; }
        object IControl.Control => Control;

        public ControlViewModel(TControl control, TModel model) : base(model)
        {
            Control = control;
            InitializeControls();
        }

        public virtual void InitializeControls() { }
    }
}