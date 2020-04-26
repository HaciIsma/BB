using Microsoft.Maps.MapControl.WPF;

namespace BakuBus.Model
{
    public enum BusType
    {
        CREALIS,
        URBANWAY
    }

    public class Bus
    {
        public string RouteCode { get; set; }
        public string Plate { get; set; }
        public string CurrentStop { get; set; }
        public string NextStop { get; set; }
        public string RouteName { get; set; }
        public string DriverName { get; set; }
        public BusType BusType { get; set; }
        public Location Location { get; set; }
    }
}
