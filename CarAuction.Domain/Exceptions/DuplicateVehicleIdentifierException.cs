namespace CarAuction.Domain.Exceptions
{
    public class DuplicateVehicleIdentifierException : Exception
    {
        public DuplicateVehicleIdentifierException(long id)
            : base($"Vehicle with Id = [{id}] already exists")
        {
        }
    }
}
