using CarAuction.Domain.Exceptions;
using CarAuction.Domain.Base;
using CarAuction.Domain.Vehicles;

namespace CarAuction.Domain.Auctions
{
    public class Auction : Entity
    {
        public bool IsActive { get; private set; }
        public decimal CurrentBid { get; private set; }
        public Vehicle Vehicle { get; private set; }

        public Auction(Vehicle vehicle)
        {
            Vehicle = vehicle;
            IsActive = false;
            CurrentBid = vehicle.StartingBid;
        }

        /// <summary>
        /// Places a bid on the auction if the bid amount is higher than the current bid.
        /// If the bid amount is lower or equal than the current bid, an InvalidBidException is thrown.
        /// </summary>
        /// <param name="bidAmount">The amount of the new bid to place on the auction.</param>
        public void PlaceBid(decimal bidAmount)
        {
            if (CurrentBid >= bidAmount)
                throw new InvalidBidException(bidAmount);

            CurrentBid = bidAmount;
        }

        /// <summary>
        /// Starts the auction by marking it as active.
        /// If the auction is already active, an AuctionAlreadyActiveException is thrown.
        /// </summary>
        public void Start()
        {
            if (IsActive)
            {
                throw new AuctionAlreadyActiveException(Vehicle.Id);
            }

            IsActive = true;
        }

        /// <summary>
        /// Closes the auction by marking it as inactive.
        /// </summary>
        public void Close()
        {
            IsActive = false;
        }
    }
}
