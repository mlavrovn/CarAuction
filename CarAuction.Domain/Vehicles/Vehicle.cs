using CarAuction.Domain.Auctions;
using CarAuction.Domain.Base;

namespace CarAuction.Domain.Vehicles
{
    public abstract class Vehicle : Entity
    {
        public abstract VehicleType VehicleType { get; }
        public string Manufacturer { get; }
        public string Model { get; }
        public int Year { get; }
        public decimal StartingBid { get; }
        public Auction Auction { get; set; }

        public Vehicle(long id, string manufacturer, string model, int year, decimal startingBid)
        {
            Id = id;
            Manufacturer = manufacturer;
            Model = model;
            Year = year;
            StartingBid = startingBid;
        }
    }
}
