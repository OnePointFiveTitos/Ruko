using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Utilities.Functions;
using static Utilities.Regexes;
using Enums;
using MVVM;
using Managers;
using System.Windows.Input;

namespace Ruko
{
    public abstract class InfoViewModel<TModel> : NodeViewModel<CustomerViewModel, TModel>, IInfo 
        where TModel : InfoModel
    {
        public string InfoName
        {
            get => Model.infoName;
            set
            {
                if (Model.infoName != value)
                {
                    Model.infoName = value;
                    OnPropertyChanged();
                }
            }
        }
        //public bool IsEditing
        //{
        //    get => Model.isEditing;
        //    set
        //    {
        //        if (Model.isEditing != value)
        //        {
        //            Model.isEditing = value;
        //            OnPropertyChanged();
        //            Parent.ReevaluateEditingState();
        //        }
        //    }
        //}
        //public bool IsEdited
        //{
        //    get => Model.isEdited;
        //    set
        //    {
        //        if (Model.isEdited != value)
        //        {
        //            Model.isEdited = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}

        public InfoViewModel(CustomerViewModel parent, TModel model, string infoName) : base(parent, model)
        {
            InfoName = $"{infoName} info";
        }

        //public virtual void ToggleEditingState() => IsEditing = !IsEditing;

        //public virtual void ToggleEditingState(bool saveChanges)
        //{
        //    ToggleEditingState();
        //    if (!IsEditing && saveChanges)
        //    {
        //        Save();
        //    }
        //}

        //public virtual void Save()
        //{
        //    //TODO: implement saving functionality
        //}
    }

    public abstract class InfoModel
    {
        internal string infoName;
        //internal bool isEditing = false;
        //internal bool isEdited = false;
    }
}