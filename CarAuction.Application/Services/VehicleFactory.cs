using CarAuction.Application.Interfaces;
using CarAuction.Application.DTOs;
using CarAuction.Domain.Vehicles;

namespace CarAuction.Application.Services
{
    public class VehicleFactory : IVehicleFactory
    {
        public Vehicle Create(CreateVehicleDto createVehicleDto)
        {
            switch(createVehicleDto.Type)
            {
                case VehicleType.Sedan:
                    return new Sedan(createVehicleDto.Id, createVehicleDto.Manufacturer, createVehicleDto.Model, createVehicleDto.Year, createVehicleDto.StartingBid, createVehicleDto.NumberOfDoors);
                case VehicleType.Truck:
                    return new Truck(createVehicleDto.Id, createVehicleDto.Manufacturer, createVehicleDto.Model, createVehicleDto.Year, createVehicleDto.StartingBid, createVehicleDto.LoadCapacity);
                case VehicleType.Hatchback:
                    return new Hatchback(createVehicleDto.Id, createVehicleDto.Manufacturer, createVehicleDto.Model, createVehicleDto.Year, createVehicleDto.StartingBid, createVehicleDto.NumberOfDoors);
                case VehicleType.SUV:
                    return new Hatchback(createVehicleDto.Id, createVehicleDto.Manufacturer, createVehicleDto.Model, createVehicleDto.Year, createVehicleDto.StartingBid, createVehicleDto.NumberOfDoors);
                default:
                    throw new ArgumentOutOfRangeException(nameof(createVehicleDto.Type));
            }
        }
    }
}
