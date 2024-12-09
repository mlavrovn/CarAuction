namespace CarAuction.Domain.Vehicles
{
    public class Sedan : Vehicle
    {
        public override VehicleType VehicleType => VehicleType.Sedan;
        public int NumberOfDoors { get; }

        public Sedan(long id, string manufacturer, string model, int year, decimal startingBid, int numberOfDoors)
            : base(id,manufacturer, model, year, startingBid)
        {
            NumberOfDoors = numberOfDoors;
        }
    }
}
