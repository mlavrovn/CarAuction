using CarAuction.Application.Interfaces;
using CarAuction.Domain.Interfaces;
using CarAuction.Domain.Exceptions;
using CarAuction.Domain.Auctions;

namespace CarAuction.Application.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly IVehicleRepository _vehicleRepository;

        public AuctionService(IAuctionRepository auctionRepository, IVehicleRepository vehicleRepository)
        {
            _auctionRepository = auctionRepository;
            _vehicleRepository = vehicleRepository;
        }

        public void StartAuction(long vehicleId)
        {
            var existedVehicle = _vehicleRepository.GetById(vehicleId);

            if (existedVehicle == null)
                throw new VehicleNotFoundException(vehicleId);

            var existedActiveAuction = _auctionRepository.GetActiveByVehicleId(existedVehicle.Id);

            if (existedActiveAuction != null)
                throw new AuctionAlreadyActiveException(existedVehicle.Id);

            var auctionToStart = new Auction(existedVehicle);

            auctionToStart.Start();

            _auctionRepository.Add(auctionToStart);
        }

        public void CloseAuction(long vehicleId)
        {
            var existedVehicle = _vehicleRepository.GetById(vehicleId);

            if (existedVehicle == null)
                throw new VehicleNotFoundException(vehicleId);

            var existedActiveAuction = _auctionRepository.GetActiveByVehicleId(existedVehicle.Id);

            if (existedActiveAuction == null)
                throw new ActiveAuctionNotFoundException(existedVehicle.Id);

            existedActiveAuction.Close();

            _auctionRepository.Update(existedActiveAuction);
        }

        public void PlaceBid(long vehicleId, decimal amount)
        {
            var existedVehicle = _vehicleRepository.GetById(vehicleId);

            if (existedVehicle == null)
                throw new VehicleNotFoundException(vehicleId);

            var existedActiveAuction = _auctionRepository.GetActiveByVehicleId(existedVehicle.Id);

            if (existedActiveAuction == null)
                throw new ActiveAuctionNotFoundException(existedVehicle.Id);

            existedActiveAuction.PlaceBid(amount);

            _auctionRepository.Update(existedActiveAuction);
        }
    }
}
