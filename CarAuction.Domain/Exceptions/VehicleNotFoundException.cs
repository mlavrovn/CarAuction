namespace CarAuction.Domain.Exceptions
{
    public class VehicleNotFoundException : Exception
    {
        public VehicleNotFoundException(long id)
            : base($"Vehicle with Id = [{id}] not found")
        {
        }
    }
}
