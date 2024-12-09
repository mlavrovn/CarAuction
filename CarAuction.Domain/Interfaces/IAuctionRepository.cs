using CarAuction.Domain.Auctions;

namespace CarAuction.Domain.Interfaces
{
    /// <summary>
    /// Interface for interacting with auction data in the repository.
    /// Inherits from <see cref="IBaseRepository{Auction}"/> to provide basic CRUD operations for auctions.
    /// </summary>
    public interface IAuctionRepository : IBaseRepository<Auction>
    {
        /// <summary>
        /// Retrieves the active auction for a given vehicle.
        /// An active auction means the auction is currently open and accepting bids.
        /// </summary>
        /// <param name="vehicleId">The ID of the vehicle for which to retrieve the active auction.</param>
        /// <returns>The active auction for the specified vehicle, or <c>null</c> if no active auction exists.</returns>
        public Auction? GetActiveByVehicleId(long vehicleId);
    }
}
