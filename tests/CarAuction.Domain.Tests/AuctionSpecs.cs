using CarAuction.Domain.Vehicles;
using CarAuction.Domain.Exceptions;
using FluentAssertions;
using CarAuction.Domain.Auctions;

namespace CarAuction.Domain.Tests
{
    public class AuctionSpecs
    {
        private Vehicle _vehicle;
        private Auction _underTest;

        [SetUp]
        public void Setup()
        {
            _vehicle = new Truck(1, "Volvo Ltd", "T100", 2024, 35000, 2.5);
            _underTest = new Auction(_vehicle);
        }

        [Test]
        public void Constructor_ShouldSetIsActiveToFalseByDefault()
        {
            _underTest.IsActive.Should().BeFalse();
        }

        [Test]
        public void PlaceBid_ShouldUpdateCurrentBid_WhenBidIsHigherThanCurrentBid()
        {
            var newBid = 36000;

            _underTest.PlaceBid(newBid);

            _underTest.CurrentBid.Should().Be(newBid);
        }

        [Test]
        public void PlaceBid_ShouldThrowInvalidBidException_WhenBidIsLowerThanCurrentBid()
        {
            var invalidBid = 34900;

            var action = () => _underTest.PlaceBid(invalidBid);

            action.Should().Throw<InvalidBidException>().WithMessage($"Bid with Amount = [{invalidBid}] invalid");
        }

        [Test]
        public void PlaceBid_ShouldThrowInvalidBidException_WhenBidIsEquealThanCurrentBid()
        {
            var invalidBid = 35000;

            var action = () => _underTest.PlaceBid(invalidBid);

            action.Should().Throw<InvalidBidException>().WithMessage($"Bid with Amount = [{invalidBid}] invalid");
        }

        [Test]
        public void Start_ShouldSetIsActiveToTrue_WhenAuctionIsNotActive()
        {
            _underTest.Start();

            _underTest.IsActive.Should().BeTrue();
        }

        [Test]
        public void Start_ShouldThrowAuctionAlreadyActiveException_WhenAuctionIsAlreadyActive()
        {
            _underTest.Start();

            var action = () => _underTest.Start();

            action.Should().Throw<AuctionAlreadyActiveException>().WithMessage($"Auction with VehicleId=[{_vehicle.Id}] is already activated");
        }

        
        [Test]
        public void Close_ShouldSetIsActiveToFalse_WhenAuctionIsActive()
        {
            _underTest.Start();

            _underTest.Close();

            _underTest.IsActive.Should().BeFalse();
        }
    }
}