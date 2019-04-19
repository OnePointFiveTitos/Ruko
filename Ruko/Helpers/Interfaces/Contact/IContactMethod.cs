namespace Ruko
{
    public interface IContactMethod
    {
        ContactTypes ContactType { get; }
        bool IsPrimary { get; set; }
    }
}