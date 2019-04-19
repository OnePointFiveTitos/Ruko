namespace Ruko
{
    public interface INameItem : IContactItem, IContactMethod
    {
        string First { get; set; }
        string Middle { get; set; }
        string Last { get; set; }
    }
}