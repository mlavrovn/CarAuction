namespace CarAuction.Domain.Vehicles
{
    public class Hatchback : Vehicle
    {
        public override VehicleType VehicleType => VehicleType.Hatchback;
        public int NumberOfDoors { get; private set; }

        public Hatchback(long id, string manufacturer, string model, int year, decimal startingBid, int numberOfDoors)
            : base(id, manufacturer, model, year, startingBid)
        {
            NumberOfDoors = numberOfDoors;
        }
    }
}
