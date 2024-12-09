using CarAuction.Application.DTOs;
using CarAuction.Application.Interfaces;
using CarAuction.Application.Services;
using CarAuction.Domain.Exceptions;
using CarAuction.Domain.Interfaces;
using CarAuction.Domain.Vehicles;
using FluentAssertions;
using NSubstitute;

namespace CarAuction.Application.Tests
{
    public class VehicleServiceSpecs
    {
        private IVehicleFactory _vehicleFactoryMock;
        private IVehicleRepository _vehicleRepositoryMock;
        private IVehicleService _underTest;

        [SetUp]
        public void Setup()
        {
            _vehicleFactoryMock = Substitute.For<IVehicleFactory>();
            _vehicleRepositoryMock = Substitute.For<IVehicleRepository>();
            _underTest = new VehicleService(_vehicleRepositoryMock, _vehicleFactoryMock);
        }

        [Test]
        public void AddVehicle_VehicleIdExists_DuplicateVehicleIdentifierException()
        {
            //Arrange
            var createVehicleDto = CreateVehicleDto();
            var existingHatchback = CreateHatchback(createVehicleDto);
            _vehicleRepositoryMock.GetById(createVehicleDto.Id).Returns(existingHatchback);

            //Act
            Action action = () => _underTest.AddVehicle(createVehicleDto);

            //Assert
            action.Should().Throw<DuplicateVehicleIdentifierException>().WithMessage($"Vehicle with Id = [{createVehicleDto.Id}] already exists");
        }

        [Test]
        public void AddVehicle_VehicleDoesNotExists_AddToRepositoryReceived()
        {
            //Arrange
            var createVehicleDto = CreateVehicleDto();
            var createdVehicle = CreateHatchback(createVehicleDto);
            Vehicle? existingVehicle = null;
            _vehicleRepositoryMock.GetById(createVehicleDto.Id).Returns(existingVehicle);
            _vehicleFactoryMock.Create(createVehicleDto).Returns(createdVehicle);

            //Act
            _underTest.AddVehicle(createVehicleDto);

            //Assert
            _vehicleRepositoryMock.Received(1).Add(Arg.Any<Vehicle>());
        }

        [Test]
        public void AddVehicle_CreateDtioIsNull_ArgumentNullException()
        {
            //Arrange
            CreateVehicleDto? createVehicleDto = null;

            //Act
            Action action = () => _underTest.AddVehicle(createVehicleDto);

            //Assert
            action.Should().Throw<ArgumentNullException>().WithMessage("Value cannot be null. (Parameter 'createVehicleDto')");
        }

        [Test]
        public void SearchVehicleBy_SearchByToRepositoryReceived()
        {
            //Arrange
            var createSearchVehicleDto = CreateSearchVehicleDto();

            //Act
            _underTest.SearchVehicleBy(createSearchVehicleDto);

            //Assert
            _vehicleRepositoryMock.Received(1).SearchBy(createSearchVehicleDto.Type, createSearchVehicleDto.Manufacturer, createSearchVehicleDto.Model, createSearchVehicleDto.Year);
        }

        private CreateVehicleDto CreateVehicleDto()
        {
            return new CreateVehicleDto()
            {
                Id = 10234,
                Type = VehicleType.Hatchback,
                StartingBid = 31000,
                NumberOfDoors = 4,
                NumberOfSeats = 5,
                Manufacturer = "Seat",
                Model = "Ibiza",
                Year = 2024
            };
        }

        private SearchVehicleDto CreateSearchVehicleDto()
        {
            return new SearchVehicleDto()
            {
                Type = VehicleType.Sedan,
                Manufacturer = "Toyota",
                Model = "RAV 4",
                Year = 2024
            };
        }


        private Hatchback CreateHatchback(CreateVehicleDto createVehicleDto)
        {
            return new Hatchback(createVehicleDto.Id, createVehicleDto.Manufacturer, createVehicleDto.Model, createVehicleDto.Year, createVehicleDto.StartingBid, createVehicleDto.NumberOfDoors);
        }
    }
}
