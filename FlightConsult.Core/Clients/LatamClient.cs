using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FlightConsult.Core.Extensions;
using FlightConsult.Core.Models;

namespace FlightConsult.Core.Clients;

public interface ILatamClient
{
    Task<IList<LatamFlight>?> GetFlightsAvaliable(FlightSearch flightSearch);
}

public class LatamClient : ILatamClient
{
    public async Task<IList<LatamFlight>?> GetFlightsAvaliable(FlightSearch flightSearch)
    {
        using var httpClient = new HttpClient();
        var uri = flightSearch.BuildRequestUri("https://dev.reserve.com.br/airapi/latam/flights", Airline.Latam);
        var response = await httpClient.GetAsync(uri);
        var jsonResponse = await response.Content.ReadAsStringAsync();

        var flights = JsonSerializer.Deserialize<List<LatamFlight>>(jsonResponse);

        return flights;
    }
}
