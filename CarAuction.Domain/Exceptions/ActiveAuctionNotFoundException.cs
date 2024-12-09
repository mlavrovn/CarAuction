namespace CarAuction.Domain.Exceptions
{
    public class ActiveAuctionNotFoundException : Exception
    {
        public ActiveAuctionNotFoundException(long vehicleId)
            : base($"Active auction with VehicleId = [{vehicleId}] not found")
        {
        }
    }
}
