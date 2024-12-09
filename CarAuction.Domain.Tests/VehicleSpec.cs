using CarAuction.Domain.Vehicles;
using FluentAssertions;
namespace CarAuction.Domain.Tests
{
    public class VehicleSpec
    {
        [Test]
        public void Constructor_TruckVehicle_ShouldInitializePropertiesCorrectly()
        {
            // Arrange
            long id = 1;
            var manufacturer = "Ford";
            var model = "F-150";
            int year = 2021;
            decimal startingBid = 25000m;
            double loadCapacity = 1000;

            // Act
            var truck = new Truck(id, manufacturer, model, year, startingBid, loadCapacity);

            // Assert
            truck.Should().NotBeNull();
            truck.Id.Should().Be(id);
            truck.Manufacturer.Should().Be(manufacturer);
            truck.Model.Should().Be(model);
            truck.Year.Should().Be(year);
            truck.StartingBid.Should().Be(startingBid);
            truck.LoadCapacity.Should().Be(loadCapacity);
            truck.VehicleType.Should().Be(VehicleType.Truck);
        }

        [Test]
        public void Constructor_SUVVehicle_ShouldInitializePropertiesCorrectly()
        {
            // Arrange
            long id = 1;
            var manufacturer = "Toyota";
            var model = "RAV 4";
            int year = 2023;
            decimal startingBid = 28000m;
            int numberOfSeats = 5;

            // Act
            var suv = new SUV(id, manufacturer, model, year, startingBid, numberOfSeats);

            // Assert
            suv.Should().NotBeNull();
            suv.Id.Should().Be(id);
            suv.Manufacturer.Should().Be(manufacturer);
            suv.Model.Should().Be(model);
            suv.Year.Should().Be(year);
            suv.StartingBid.Should().Be(startingBid);
            suv.NumberOfSeats.Should().Be(numberOfSeats);
            suv.VehicleType.Should().Be(VehicleType.SUV);
        }

        [Test]
        public void Constructor_SedanVehicle_ShouldInitializePropertiesCorrectly()
        {
            // Arrange
            long id = 1;
            var manufacturer = "Toyota";
            var model = "Corolla";
            int year = 2023;
            decimal startingBid = 28000m;
            int numberOfDoors = 4;

            // Act
            var sedan = new Sedan(id, manufacturer, model, year, startingBid, numberOfDoors);

            // Assert
            sedan.Should().NotBeNull();
            sedan.Id.Should().Be(id);
            sedan.Manufacturer.Should().Be(manufacturer);
            sedan.Model.Should().Be(model);
            sedan.Year.Should().Be(year);
            sedan.StartingBid.Should().Be(startingBid);
            sedan.NumberOfDoors.Should().Be(numberOfDoors);
            sedan.VehicleType.Should().Be(VehicleType.Sedan);
        }
    }
}
