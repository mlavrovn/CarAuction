namespace CarAuction.Domain.Exceptions
{
    public class InvalidBidException : Exception
    {
        public InvalidBidException(decimal amount)
          : base($"Bid with Amount = [{amount}] invalid")
        {
        }
    }
}
