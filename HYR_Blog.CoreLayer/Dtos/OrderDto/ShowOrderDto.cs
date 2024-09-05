namespace HYR_Blog.CoreLayer.Dtos.OrderDto;

public class ShowOrderDto
{
    public int OrderId { get; set; }
    public string SerialNumber { get; set; }
    public string PersonName { get; set; }
    public int SumPrise { get; set; }
    public string CreationDate { get; set; }
    public string Status { get; set; }
    public int StatusPriority { get; set; }
    public string? SendCode { get; set; }
    public string Address { get; set; }
    public Dictionary<string , int> NameAndCountProduct { get; set; }

}