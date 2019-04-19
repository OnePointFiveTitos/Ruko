namespace Ruko
{
    public interface IEmailItem : IContactItem, IContactMethod
    {
        string Handle { get; set; }
        string Domain { get; set; }
        string Register { get; set; }
    }
}