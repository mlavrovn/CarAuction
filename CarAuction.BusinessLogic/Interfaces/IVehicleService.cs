using CarAuction.Application.DTOs;
using CarAuction.Domain.Vehicles;

namespace CarAuction.Application.Interfaces
{
    /// <summary>
    /// Interface for managing vehicles.
    /// Provides methods to add new vehicles and search for vehicles based on specific criteria.
    /// </summary>
    public interface IVehicleService
    {
        /// <summary>
        /// Adds a new vehicle to the system.
        /// </summary>
        /// <param name="vehicleCreateDto">Data transfer object containing the information of the vehicle to be added.</param>
        void AddVehicle(CreateVehicleDto vehicleCreateDto);

        /// <summary>
        /// Searches for vehicles based on the provided search criteria.
        /// </summary>
        /// <param name="vehicleSearchCriteriaDto">Data transfer object containing the search criteria.</param>
        /// <returns>A list of vehicles that match the search criteria.</returns>
        List<Vehicle> SearchVehicleBy(SearchVehicleDto vehicleSearchCriteriaDto);
    }
}
