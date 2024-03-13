using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FlightConsult.Core.Extensions;
using FlightConsult.Core.Models;

namespace FlightConsult.Core.Clients;

public interface IGolClient
{
    Task<IList<GolFlight>?> GetFlightsAvaliable(FlightSearch flightSearch);
}

public class GolClient : IGolClient
{
    public async Task<IList<GolFlight>?> GetFlightsAvaliable(FlightSearch flightSearch)
    {
        using var httpClient = new HttpClient();
        var uri = flightSearch.BuildRequestUri("https://dev.reserve.com.br/airapi/gol/getavailability", Airline.Gol);
        var response = await httpClient.GetAsync(uri);
        var jsonResponse = await response.Content.ReadAsStringAsync();

        var flights = JsonSerializer.Deserialize<List<GolFlight>>(jsonResponse);

        return flights;
    }
}
