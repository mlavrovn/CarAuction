namespace CarAuction.Application.Interfaces
{
    /// <summary>
    /// Interface for managing vehicle auctions.
    /// Provides methods to start, close, and place bids on auctions.
    /// </summary>
    public interface IAuctionService
    {
        /// <summary>
        /// Starts an auction for the specified vehicle.
        /// </summary>
        /// <param name="vehicleId">The ID of the vehicle to start the auction for.</param>
        void StartAuction(long vehicleId);

        /// <summary>
        /// Closes the auction for the specified vehicle.
        /// The auction is considered completed and no further bids can be placed.
        /// </summary>
        /// <param name="vehicleId">The ID of the vehicle to close the auction for.</param>
        public void CloseAuction(long vehicleId);

        /// <summary>
        /// Places a bid on the specified vehicle's auction.
        /// The bid amount must be higher than the current highest bid.
        /// </summary>
        /// <param name="vehicleId">The ID of the vehicle to place a bid on.</param>
        /// <param name="amount">The bid amount.</param>
        public void PlaceBid(long vehicleId, decimal amount);
    }
}
