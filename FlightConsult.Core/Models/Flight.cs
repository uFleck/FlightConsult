using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightConsult.Core.Models;

public class Flight
{
    public required string Voo { get; set; }
    public required string Companhia { get; set; }
    public required string Origem { get; set; }
    public required string Destino { get; set; }
    public required DateTime Partida { get; set; }
    public required DateTime Chegada { get; set; }
    public required double Tarifa { get; set; }

    public static implicit operator Flight(LatamFlight latamFlight) =>
        new()
        {
            Voo = latamFlight.FlightID,
            Companhia = latamFlight.Airline,
            Origem = latamFlight.DepartureAirport,
            Destino = latamFlight.ArrivalAirport,
            Partida = latamFlight.FlightStart,
            Chegada = latamFlight.FlightEnd,
            Tarifa = latamFlight.TotalFare
        };

    public static implicit operator Flight(GolFlight latamFlight) =>
        new()
        {
            Voo = latamFlight.FlightNumber,
            Companhia = latamFlight.Carrier,
            Origem = latamFlight.OriginAirport,
            Destino = latamFlight.DestinationAirport,
            Partida = latamFlight.DepartureDate,
            Chegada = latamFlight.ArrivalDate,
            Tarifa = latamFlight.FarePrice
        };
}
