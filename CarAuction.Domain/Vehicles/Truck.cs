namespace CarAuction.Domain.Vehicles
{
    public class Truck : Vehicle
    {
        public override VehicleType VehicleType =>  VehicleType.Truck;
        public double LoadCapacity { get; }

        public Truck(long id, string manufacturer, string model, int year, decimal startingBid, double loadCapacity)
            : base(id, manufacturer, model, year, startingBid)
        {
            LoadCapacity = loadCapacity;
        }
    }
}
