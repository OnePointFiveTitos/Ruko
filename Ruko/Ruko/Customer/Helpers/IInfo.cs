namespace Ruko
{
    public interface IInfo
    {
        string InfoName { get; set; }
        bool IsEdited { get; set; }
        bool IsEditing { get; set; }

        void ToggleEditingState();
        void ToggleEditingState(bool saveChanges);
        void Save();
    }
}