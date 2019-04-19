using System;

namespace Xne_Utilities
{
    public abstract class EditableBase
    {
        public virtual bool IsEditing { get; set; }
        public event EventHandler Editing;
        public event EventHandler EditApplied;
        public event EventHandler EditCanceled;

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
}