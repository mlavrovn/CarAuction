using CarAuction.Domain.Exceptions;
using CarAuction.Domain.Interfaces;
using CarAuction.Domain.Vehicles;
using CarAuction.Application.Services;
using FluentAssertions;
using NSubstitute;
using CarAuction.Application.Interfaces;
using CarAuction.Domain.Auctions;

namespace CarAuction.BusinessLogic.Tests
{
    public class AuctionServiceSpecs
    {
        private IAuctionRepository _auctionRepositoryMock;
        private IVehicleRepository _vehicleRepositoryMock;
        private IAuctionService _underTest;

        [SetUp]
        public void Setup()
        {
            _auctionRepositoryMock = Substitute.For<IAuctionRepository>();
            _vehicleRepositoryMock = Substitute.For<IVehicleRepository>();
            _underTest = new AuctionService(_auctionRepositoryMock, _vehicleRepositoryMock);
        }

        [Test]
        public void StartAuction_VehicleNotExists_ThrowVehicleNotFoundException()
        {
            //Arrange
            var vehicleId = 1;
            Vehicle? notExistingVehicle = null;
            _vehicleRepositoryMock.GetById(vehicleId).Returns(notExistingVehicle);

            //Act
            Action action = () => _underTest.StartAuction(vehicleId);

            //Assert
            action.Should().Throw<VehicleNotFoundException>().WithMessage($"Vehicle with Id = [{vehicleId}] not found");
        }


        [Test]
        public void StartAuction_ActiveAuctionExists_ThrowAuctionAlreadyActiveException()
        {
            //Arrange
            var vehicle = CreateVehicle();
            var existingAuction = new Auction(vehicle);
            _vehicleRepositoryMock.GetById(vehicle.Id).Returns(vehicle);
            _auctionRepositoryMock.GetActiveByVehicleId(vehicle.Id).Returns(existingAuction);

            //Act
            Action action = () => _underTest.StartAuction(vehicle.Id);

            //Assert
            action.Should().Throw<AuctionAlreadyActiveException>().WithMessage($"Auction with VehicleId=[{vehicle.Id}] is already activated");
        }

        [Test]
        public void CloseAuction_VehicleNotExists_ThrowVehicleNotFoundException()
        {
            //Arrange
            var vehicleId = 1;
            Vehicle? notExistingVehicle = null;
            _vehicleRepositoryMock.GetById(vehicleId).Returns(notExistingVehicle);

            //Act
            Action action = () => _underTest.CloseAuction(vehicleId);

            //Assert
            action.Should().Throw<VehicleNotFoundException>().WithMessage($"Vehicle with Id = [{vehicleId}] not found");
        }

        [Test]
        public void CloseAuction_ActiveAuctionExists_ThrowAuctionAlreadyActiveException()
        {
            //Arrange
            var vehicle = CreateVehicle();
            Auction? notExistingAuction = null;
            _vehicleRepositoryMock.GetById(vehicle.Id).Returns(vehicle);
            _auctionRepositoryMock.GetActiveByVehicleId(vehicle.Id).Returns(notExistingAuction);

            //Act
            Action action = () => _underTest.CloseAuction(vehicle.Id);

            //Assert
            action.Should().Throw<ActiveAuctionNotFoundException>().WithMessage($"Active auction with VehicleId = [{vehicle.Id}] not found");
        }

        [Test]
        public void StartAuction_ValidRequest_ShouldCallAuctionRepositoryAdd()
        {
            //Arrange
            var vehicle = CreateVehicle();
            Auction? nonExistingAuction = null;
            _vehicleRepositoryMock.GetById(vehicle.Id).Returns(vehicle);
            _auctionRepositoryMock.GetActiveByVehicleId(vehicle.Id).Returns(nonExistingAuction);

            //Act
            _underTest.StartAuction(vehicle.Id);

            //Assert
            _auctionRepositoryMock.Received(1).Add(Arg.Is<Auction>(auction => auction.Vehicle == vehicle));
        }

        [Test]
        public void CloseAuction_ValidRequest_ShouldCallAuctionRepositoryUpdate()
        {
            //Arrange
            var vehicle = CreateVehicle();
            var existingAuction = new Auction(vehicle);
            _vehicleRepositoryMock.GetById(vehicle.Id).Returns(vehicle);
            _auctionRepositoryMock.GetActiveByVehicleId(vehicle.Id).Returns(existingAuction);

            //Act
            _underTest.CloseAuction(vehicle.Id);

            //Assert
            _auctionRepositoryMock.Received(1).Update(Arg.Is<Auction>(auction => auction.Vehicle == vehicle));
            _auctionRepositoryMock.Received(1).Update(Arg.Is<Auction>(auction => !auction.IsActive));
        }

        [Test]
        public void PlaceBid_ValidRequest_ShouldCallAuctionRepositoryUpdate()
        {
            //Arrange
            var vehicle = CreateVehicle();
            var bid = vehicle.StartingBid + 1000;
            var activeAuction = new Auction(vehicle);
            activeAuction.Start();
            _vehicleRepositoryMock.GetById(vehicle.Id).Returns(vehicle);
            _auctionRepositoryMock.GetActiveByVehicleId(vehicle.Id).Returns(activeAuction);

            //Act
            _underTest.PlaceBid(vehicle.Id, bid);

            //Assert
            _auctionRepositoryMock.Received(1).Update(Arg.Is<Auction>(auction => auction.Vehicle == vehicle));
            _auctionRepositoryMock.Received(1).Update(Arg.Is<Auction>(auction => auction.IsActive));
            _auctionRepositoryMock.Received(1).Update(Arg.Is<Auction>(auction => auction.CurrentBid == bid));
        }

        [Test]
        public void PlaceBid_VehicleNotExists_ThrowVehicleNotFoundException()
        {
            //Arrange
            var bid = 3000;
            var vehicleId = 1;
            Vehicle? nonExistingVehicle = null;
            _vehicleRepositoryMock.GetById(vehicleId).Returns(nonExistingVehicle);

            //Act
            Action action = () => _underTest.PlaceBid(vehicleId, bid);

            //Assert
            action.Should().Throw<VehicleNotFoundException>().WithMessage($"Vehicle with Id = [{vehicleId}] not found");
        }

        [Test]
        public void PlaceBid_AuctionNotExists_ThrowActiveAuctionNotFoundException()
        {
            //Arrange
            var bid = 3000;
            var vehicle = CreateVehicle();
            Auction? nonExistingActiveAuction = null;
            _vehicleRepositoryMock.GetById(vehicle.Id).Returns(vehicle);
            _auctionRepositoryMock.GetActiveByVehicleId(vehicle.Id).Returns(nonExistingActiveAuction);

            //Act
            Action action = () => _underTest.PlaceBid(vehicle.Id, bid);

            //Assert
            action.Should().Throw<ActiveAuctionNotFoundException>().WithMessage($"Active auction with VehicleId = [{vehicle.Id}] not found");
        }

        private static Sedan CreateVehicle()
        {
            return new Sedan(id: 1, manufacturer: "Toyota Ltd", model: "Corolla", year: 2020, startingBid: 1000, 4);
        }
    }
}