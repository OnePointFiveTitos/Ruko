using System;
using Xne_Utilities;

namespace Xne_MVVM
{
    public abstract class ViewModel<TModel> : ObservableObject, IModeled<TModel>
    {
        public TModel Model { get; }
        public ViewModel(TModel model)
        {
            Model = model;
        }
    }
}