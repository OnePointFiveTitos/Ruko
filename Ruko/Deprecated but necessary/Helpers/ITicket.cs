zusing System;
namespace Ruko
{
    public interface ITicket
    {
        bool IsOpened { get; set; }
        bool IsSelected { get; set; }
        DateTime Date { get; set; }
        NameViewModel Name { get; set; }
        AddressViewModel Address { get; set; }
        string TimeIn { get; set; }
        string TimeOut { get; set; }
        string Remarks { get; set; }
        string Technician { get; set; }
        float SubTotal { get; set; }
        float Tax { get; set; }
        float Total { get; set; }
        UserParameter PayementType { get; set; }
    }
}