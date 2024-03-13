namespace FlightConsult.Core.Models;

public class LatamFlight
{
    public required string FlightID { get; set; }
    public required string Airline { get; set; }
    public required DateTime FlightStart { get; set; }
    public required DateTime FlightEnd { get; set; }
    public required string DepartureAirport { get; set; }
    public required string ArrivalAirport { get; set; }
    public required double TotalFare { get; set; }
}
