using CarAuction.Domain.Vehicles;

namespace CarAuction.Application.DTOs
{
    public class SearchVehicleDto
    {
        public VehicleType? Type { get; set; }
        public string? Manufacturer { get; set; }
        public string? Model { get; set; }
        public int? Year { get; set; }
    }
}
