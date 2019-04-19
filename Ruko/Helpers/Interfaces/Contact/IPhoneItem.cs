namespace Ruko
{
    public interface IPhoneItem : IContactItem, IContactMethod
    {
        int Areacode { get; set; }
        int Prefix { get; set; }
        int Line { get; set; }
        int? CountryCode { get; set; }
        int? Extension { get; set; }
    }
}