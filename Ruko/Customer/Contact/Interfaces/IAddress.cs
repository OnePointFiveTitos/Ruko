namespace Ruko
{
    public interface IAddress
    {
        string Street { get; set; }
        string City { get; set; }
        int Zipcode { get; set; }
        int? Extension { get; set; }
        string CrossStreet { get; set; }
    }
}