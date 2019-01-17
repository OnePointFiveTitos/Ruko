using MVVM;

namespace Ruko
{
    public interface IMainInfo
    {
        string InfoName { get; set; }
        bool IsEdited { get; set; }
        bool IsEditing { get; set; }
        bool IsOpened { get; set; }
        bool IsSelected { get; set; }
        void Edit(int index, bool saveChanges = true);
        void Save();
    }
}