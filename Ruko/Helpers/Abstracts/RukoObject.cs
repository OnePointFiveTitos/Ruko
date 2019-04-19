using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xne_MVVM;
using Xne_Utilities;

namespace Ruko
{
    public abstract class RukoObject<TParent, TModel> : NodeViewModel<TParent, TModel>, IRukoObject where TModel : RukoObjectModel
    {
        public virtual bool IsEditing
        {
            get => Model.isEditing;
            set
            {
                if (Model.isEditing != value)
                {
                    Model.isEditing = value;
                    OnPropertyChanged();
                }
            }
        }
        public virtual bool IsEditable
        {
            get => Model.isEditable;
            set
            {
                if (Model.isEditable != value)
                {
                    Model.isEditable = value;
                    OnPropertyChanged();
                }
            }
        }
        public event EventHandler Editing;
        public event EventHandler EditApplied;
        public event EventHandler EditCanceled;
        public RukoObject(TParent parent, TModel model) : base(parent, model)
        {
        }

        public virtual void Edit()
        {
            IsEditing = true;
            Editing?.Invoke(this, null);
        }

        public virtual void ApplyEdit()
        {
            IsEditing = false;
            EditApplied?.Invoke(this, null);
        }

        public virtual void CancelEdit()
        {
            IsEditing = false;
            EditCanceled?.Invoke(this, null);
        }
    }

    public abstract class RukoObjectModel
    {
        internal bool isEditable;
        internal bool isEditing;
    }
}