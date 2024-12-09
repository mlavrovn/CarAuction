namespace CarAuction.Domain.Exceptions
{
    public class AuctionAlreadyActiveException : Exception
    {
        public AuctionAlreadyActiveException(long vehicleId)
        : base($"Auction with VehicleId=[{vehicleId}] is already activated")
        {
        }
    }
}
