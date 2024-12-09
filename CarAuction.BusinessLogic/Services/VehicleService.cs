using CarAuction.Domain.Exceptions;
using CarAuction.Application.Interfaces;
using CarAuction.Domain.Interfaces;
using CarAuction.Application.DTOs;
using CarAuction.Domain.Vehicles;

namespace CarAuction.Application.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IVehicleFactory _vehicleFactory;

        public VehicleService(IVehicleRepository vehicleRepository, IVehicleFactory vehicleFactory)
        {
            _vehicleRepository = vehicleRepository;
            _vehicleFactory = vehicleFactory;
        }

        public void AddVehicle(CreateVehicleDto createVehicleDto)
        {
            if (createVehicleDto == null)
                throw new ArgumentNullException(nameof(createVehicleDto));

            var existedVehicle = _vehicleRepository.GetById(createVehicleDto.Id);

            if (existedVehicle != null)
                throw new DuplicateVehicleIdentifierException(existedVehicle.Id);

            var newVehicle = _vehicleFactory.Create(createVehicleDto);

            _vehicleRepository.Add(newVehicle);
        }

        public List<Vehicle> SearchVehicleBy(SearchVehicleDto vehicleSearchCriteria)
        {
            return _vehicleRepository.SearchBy(vehicleSearchCriteria.Type, vehicleSearchCriteria.Manufacturer, vehicleSearchCriteria.Model, vehicleSearchCriteria.Year);
        }
    }
}
