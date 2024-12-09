using CarAuction.Application.DTOs;
using CarAuction.Application.Services;
using CarAuction.Application.Interfaces;
using CarAuction.Domain.Vehicles;
using FluentAssertions;

namespace CarAuction.Application.Tests
{
    public class VehicleFactorySpecs
    {
        private IVehicleFactory _underTest;

        [SetUp]
        public void SetUp()
        {
            _underTest = new VehicleFactory();
        }

        [Test]
        public void Create_ShouldReturnSedan_WhenVehicleTypeIsSedan()
        {
            // Arrange
            var createVehicleDto = new CreateVehicleDto
            {
                Id = 1,
                Type = VehicleType.Sedan,
                Manufacturer = "Toyota",
                Model = "Corolla",
                Year = 2020,
                StartingBid = 15000,
                NumberOfDoors = 4
            };

            // Act
            var vehicle = _underTest.Create(createVehicleDto);

            // Assert
            vehicle.Should().BeOfType<Sedan>();
            vehicle.Id.Should().Be(createVehicleDto.Id);
            vehicle.Manufacturer.Should().Be(createVehicleDto.Manufacturer);
            vehicle.Model.Should().Be(createVehicleDto.Model);
            vehicle.Year.Should().Be(createVehicleDto.Year);
            vehicle.StartingBid.Should().Be(createVehicleDto.StartingBid);
            ((Sedan)vehicle).NumberOfDoors.Should().Be(createVehicleDto.NumberOfDoors);
        }

        [Test]
        public void Create_ShouldReturnTruck_WhenVehicleTypeIsTruck()
        {
            // Arrange
            var createVehicleDto = new CreateVehicleDto
            {
                Id = 2,
                Type = VehicleType.Truck,
                Manufacturer = "Ford",
                Model = "F-100",
                Year = 2021,
                StartingBid = 25000,
                LoadCapacity = 1000
            };

            // Act
            var vehicle = _underTest.Create(createVehicleDto);

            // Assert
            vehicle.Should().BeOfType<Truck>();
            vehicle.Id.Should().Be(createVehicleDto.Id);
            vehicle.Manufacturer.Should().Be(createVehicleDto.Manufacturer);
            vehicle.Model.Should().Be(createVehicleDto.Model);
            vehicle.Year.Should().Be(createVehicleDto.Year);
            vehicle.StartingBid.Should().Be(createVehicleDto.StartingBid);
            ((Truck)vehicle).LoadCapacity.Should().Be(createVehicleDto.LoadCapacity);
        }

        [Test]
        public void Create_ShouldReturnHatchback_WhenVehicleTypeIsHatchback()
        {
            // Arrange
            var createVehicleDto = new CreateVehicleDto
            {
                Type = VehicleType.Hatchback,
                Id = 3,
                Manufacturer = "Honda",
                Model = "Civic",
                Year = 2019,
                StartingBid = 18000,
                NumberOfDoors = 5
            };

            // Act
            var vehicle = _underTest.Create(createVehicleDto);

            // Assert
            vehicle.Should().BeOfType<Hatchback>();
            vehicle.Id.Should().Be(createVehicleDto.Id);
            vehicle.Manufacturer.Should().Be(createVehicleDto.Manufacturer);
            vehicle.Model.Should().Be(createVehicleDto.Model);
            vehicle.Year.Should().Be(createVehicleDto.Year);
            vehicle.StartingBid.Should().Be(createVehicleDto.StartingBid);
            ((Hatchback)vehicle).NumberOfDoors.Should().Be(createVehicleDto.NumberOfDoors);
        }

        [Test]
        public void Create_ShouldReturnSUV_WhenVehicleTypeIsSUV()
        {
            // Arrange
            var createVehicleDto = new CreateVehicleDto
            {
                Id = 4,
                Type = VehicleType.SUV,
                Manufacturer = "BMW",
                Model = "X3",
                Year = 2022,
                StartingBid = 50000,
                NumberOfDoors = 5
            };

            // Act
            var vehicle = _underTest.Create(createVehicleDto);

            // Assert
            vehicle.Should().BeOfType<Hatchback>();
            vehicle.Id.Should().Be(createVehicleDto.Id);
            vehicle.Manufacturer.Should().Be(createVehicleDto.Manufacturer);
            vehicle.Model.Should().Be(createVehicleDto.Model);
            vehicle.Year.Should().Be(createVehicleDto.Year);
            vehicle.StartingBid.Should().Be(createVehicleDto.StartingBid);
            ((Hatchback)vehicle).NumberOfDoors.Should().Be(createVehicleDto.NumberOfDoors);
        }

        [Test]
        public void Create_ShouldThrowArgumentOutOfRangeException_WhenVehicleTypeIsInvalid()
        {
            // Arrange
            var wrongType = (VehicleType)10;
            var createVehicleDto = new CreateVehicleDto
            {
                Id = 5,
                Type = wrongType,
                Manufacturer = "Unknown",
                Model = "Unknown",
                Year = 2023,
                StartingBid = 20000,
                NumberOfDoors = 4
            };

            // Act
            Action act = () => _underTest.Create(createVehicleDto);

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
