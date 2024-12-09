using CarAuction.Domain.Vehicles;

namespace CarAuction.Application.DTOs
{
    public class CreateVehicleDto
    {
        public long Id { get; set; }
        public VehicleType Type { get; set; }
        public decimal StartingBid { get; set; }
        public int NumberOfDoors { get; set; }
        public int NumberOfSeats { get; set; }
        public double LoadCapacity { get; set; }
        public string Manufacturer { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int Year { get; set; }
    }
}
