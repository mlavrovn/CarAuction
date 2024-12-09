namespace CarAuction.Domain.Vehicles
{
    public class SUV : Vehicle
    {
        public override VehicleType VehicleType { get; } = VehicleType.SUV;
        public int NumberOfSeats { get; }

        public SUV(long id, string manufacturer, string model, int year, decimal startingBid, int numberOfSeats)
            : base(id, manufacturer, model, year, startingBid)
        {
            NumberOfSeats = numberOfSeats;
        }
    }
}
