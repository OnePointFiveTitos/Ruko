namespace Ruko
{
    public interface IPhoneItem : IContactItem
    {
        int Areacode { get; set; }
        int Prefix { get; set; }
        int Line { get; set; }
        int? CountryCode { get; set; }
        int? Extension { get; set; }
    }
}