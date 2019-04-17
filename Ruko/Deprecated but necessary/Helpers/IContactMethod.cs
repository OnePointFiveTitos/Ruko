namespace Ruko
{
    public interface IContactMethod
    {
        bool IsPreferred { get; set; }
        ContactTypes ContactType { get; set; }
    }
}