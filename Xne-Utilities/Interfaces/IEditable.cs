using System;

namespace Xne_Utilities
{
    public interface IEditable
    {
        bool IsEditable { get; set; }
        bool IsEditing { get; set; }
        event EventHandler Editing;
        event EventHandler EditApplied;
        event EventHandler EditCanceled;
        void Edit();
        void ApplyEdit();
        void CancelEdit();
    }
}