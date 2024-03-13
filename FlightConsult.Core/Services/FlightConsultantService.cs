using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightConsult.Core.Clients;
using FlightConsult.Core.Models;

namespace FlightConsult.Core.Services;

public interface IFlightConsultantService
{
    Task<IEnumerable<Flight>> GetAvaliableFlights(FlightSearch flightSearch);
}
public class FlightConsultantService(ILatamClient latamClient, IGolClient golClient) : IFlightConsultantService
{
    public async Task<IEnumerable<Flight>> GetAvaliableFlights(FlightSearch flightSearch)
    {
        var latamFlights = await latamClient.GetFlightsAvaliable(flightSearch);
        var golFlights = await golClient.GetFlightsAvaliable(flightSearch);

        var flights = new List<Flight>();

        if (latamFlights is not null)
            foreach (var flight in latamFlights)
                flights.Add(flight);

        if (golFlights is not null)
            foreach (var flight in golFlights)
                flights.Add(flight);

        var ordenedFlights = flights
            .OrderBy(flight => flight.Tarifa)
            .ThenBy(flight => flight.Partida);

        return ordenedFlights;
    }
}
