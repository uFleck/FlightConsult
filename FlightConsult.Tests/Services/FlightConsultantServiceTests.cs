using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightConsult.Core.Clients;
using FlightConsult.Core.Services;
using FluentAssertions;

namespace FlightConsult.Tests.Services;

[TestClass]
public class FlightConsultantServiceTests
{
    [TestMethod]
    public async Task GetAvaliableFlights_ShouldReturnFlightsInOrderOfFareThenByDepartureDate()
    {
        var latamClient = new LatamClient();
        var golClient = new GolClient();
        var service = new FlightConsultantService(latamClient, golClient);

        var avaliableFlights = await service.GetAvaliableFlights(new("Rio de Janeiro", "São Paulo", new(2024, 06, 20)));

        var flightsList = avaliableFlights.ToList();

        var previousFare = 0.0;
        var previousDepartureDate = new DateTime();
        for (var i = 0; i < flightsList.Count; i++)
        {
            if (i == 0)
            {
                previousFare = flightsList[0].Tarifa;
                previousDepartureDate = flightsList[0].Partida.Date;
            }

            flightsList[i].Tarifa.Should().BeGreaterThanOrEqualTo(previousFare);
            flightsList[i].Partida.Date.Should().BeOnOrAfter(previousDepartureDate.Date);
        }
    }
}
