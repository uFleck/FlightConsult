namespace FlightConsult.Core.Models;

public class GolFlight
{
    public required string FlightNumber { get; set; }
    public required string Carrier { get; set; }
    public required DateTime DepartureDate { get; set; }
    public required DateTime ArrivalDate { get; set; }
    public required string OriginAirport { get; set; }
    public required string DestinationAirport { get; set; }
    public required double FarePrice { get; set; }
}
