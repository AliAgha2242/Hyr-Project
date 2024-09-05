namespace HYR_Blog.CoreLayer.Dtos.CartDto
{
    public class TransportationDto
    {
        public int TransportationId { get; set; }
        public string TransportationCompany { get; set; }
        public int PrisePerKg { get; set; }
        public int InitialPrise { get; set; }
        public int SendPriseByWeight { get; set; }
    }
}
