using BakuBus.Model;
using Microsoft.Maps.MapControl.WPF;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace BakuBus.Services
{
    public class BakuBusService
    {
        public IEnumerable<Bus> GetAllBuses()
        {
            var client = new HttpClient();
            var link = "https://www.bakubus.az/az/ajax/apiNew1";
            dynamic busses = JsonConvert.DeserializeObject(client.GetAsync(link).Result.Content.ReadAsStringAsync().Result);

            foreach (var item in busses.BUS)
            {
                dynamic bus = item["@attributes"];
                string latitude = bus["LATITUDE"];
                string longitude = bus["LONGITUDE"];
                Location location = new Location(double.Parse(latitude.Replace(",", ".")), double.Parse(longitude.Replace(",", ".")));

                var b = new Bus()
                {
                    DriverName = bus["DRIVER_NAME"],
                    Location = location,
                    NextStop = bus["CURRENT_STOP"],
                    Plate = bus["PLATE"],
                    CurrentStop = bus["PREV_STOP"],
                    RouteCode = bus["DISPLAY_ROUTE_CODE"],
                    RouteName = bus["ROUTE_NAME"],
                };

                AllBuses.Add(b);
            }

            return AllBuses;
        }

        public List<Bus> AllBuses { get; set; } = new List<Bus>();
        public List<Bus> BusesForRouteCode { get; set; } = new List<Bus>();
        public IEnumerable<Bus> GetAllBusesByRouteCode(string routCode)
        {
            BusesForRouteCode.Clear();

            if (routCode == "General list")
            {
                return AllBuses;
            }

            foreach (var item in AllBuses)
            {
                if (item.RouteCode == routCode)
                {
                    BusesForRouteCode.Add(item);
                }
            }

            return BusesForRouteCode;

        }
    }
}
