using CarAuction.Application.DTOs;
using CarAuction.Domain.Vehicles;

namespace CarAuction.Application.Interfaces
{
    /// <summary>
    /// Interface for creating a new <see cref="Vehicle"/>.
    /// Defines the contract for factories that are responsible for creating a <see cref="Vehicle"/> object.
    /// </summary>
    public interface IVehicleFactory
    {
        /// <summary>
        /// Creates a new <see cref="Vehicle"/> based on the provided <see cref="CreateVehicleDto"/>.
        /// </summary>
        /// <param name="vehicleCreateDto">The data transfer object containing the details required to create a new vehicle.</param>
        /// <returns>A new instance of the <see cref="Vehicle"/> class.</returns>
        public Vehicle Create(CreateVehicleDto vehicleCreateDto);
    }
}
