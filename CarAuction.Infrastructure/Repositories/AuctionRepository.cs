using CarAuction.Domain.Auctions;
using CarAuction.Domain.Interfaces;

namespace CarAuction.Infrastructure.Repositories
{
    public class AuctionRepository : IAuctionRepository
    {
        private List<Auction> _auctions = new List<Auction>();

        public Auction Add(Auction entity)
        {
            _auctions.Add(entity);
            return entity;
        }

        public Auction? GetActiveByVehicleId(long vehicleId)
        {
            return _auctions.FirstOrDefault(a => a.Vehicle.Id == vehicleId && a.IsActive);
        }

        public void Delete(Auction entity)
        {
            var auctionToRemove = _auctions.FirstOrDefault(a => a.Id == entity.Id);
            if (auctionToRemove != null)
            {
                _auctions.Remove(auctionToRemove);
            }
        }

        public IEnumerable<Auction> GetAll()
        {
            return _auctions;
        }

        public Auction? GetById(long id)
        {
            return _auctions.FirstOrDefault(a => a.Id == id);
        }

        public Auction Update(Auction entity)
        {
            return entity;
        }
    }
}
