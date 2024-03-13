using System.Web;
using FlightConsult.Core.Models;

namespace FlightConsult.Core.Extensions;

public static class FlightSearchExtensions
{
    public static string BuildRequestUri(this FlightSearch queryString, string baseUri, Airline airline)
    {
        var uriBuilder = new UriBuilder(baseUri);
        var query = HttpUtility.ParseQueryString(uriBuilder.Query);

        if (airline == Airline.Gol)
        {
            query["origin"] = queryString.Origin;
            query["destination"] = queryString.Destination;
            query["date"] = queryString.Date.Date.ToString("yyyy-MM-dd");
        }
        else
        {
            query["departureCity"] = queryString.Origin;
            query["arrivalCity"] = queryString.Destination;
            query["departureDate"] = queryString.Date.Date.ToString("yyyy-MM-dd");
        }

        uriBuilder.Query = query.ToString();
        var url = uriBuilder.ToString();
        return url;
    }
}

public enum Airline
{
    Gol,
    Latam
}
