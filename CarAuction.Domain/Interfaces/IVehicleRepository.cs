using CarAuction.Domain.Vehicles;

namespace CarAuction.Domain.Interfaces
{
    /// <summary>
    /// Interface for interacting with vehicle data in the repository.
    /// Inherits from <see cref="IBaseRepository{Vehicle}"/> to provide basic CRUD operations for vehicles.
    /// </summary>
    public interface IVehicleRepository : IBaseRepository<Vehicle>
    {
        /// <summary>
        /// Searches for vehicles based on optional criteria such as vehicle type, manufacturer, model, and year.
        /// </summary>
        /// <param name="vehicleType">Optional filter for the vehicle type (e.g., Sedan, SUV, etc.).</param>
        /// <param name="manufacturer">Optional filter for the vehicle manufacturer (e.g., Toyota, Ford, etc.).</param>
        /// <param name="model">Optional filter for the vehicle model (e.g., Corolla, Focus, etc.).</param>
        /// <param name="year">Optional filter for the vehicle manufacturing year.</param>
        /// <returns>A list of vehicles matching the search criteria. If no criteria is provided, returns all vehicles.</returns>
        public List<Vehicle> SearchBy(VehicleType? vehicleType, string? manufacturer, string? model, int? year);
    }
}
