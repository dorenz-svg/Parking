using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Moq;
using AutoFixture;
using FluentAssertions;
using Parking.Abstractions.Repositories;
using System.Collections.Generic;
using Parking.Abstractions.Models;

namespace Parking.Core.Tests.PlacesService
{
    public class GetPlaceTest
    {
        private readonly Fixture _fixture;
        private readonly Services.PlacesService _service;
        private readonly Mock<IPlacesRepository> _placesRepository;

        public GetPlaceTest()
        {
            _fixture = new Fixture();
            _placesRepository = new Mock<IPlacesRepository>();
            _service = new Services.PlacesService(
                _placesRepository.Object,
                null,
                null
                );
        }

        [Fact]
        public async Task Get_ValidInput_ReturnsPlacesArray()
        {
            //Arrange
            var mockArray = _fixture.Create<GetPlacesModel[]>();
            _placesRepository
               .Setup(x => x.GetPlaces())
               .ReturnsAsync(() => mockArray);

            //Act
            var result = await _service.GetPlaces();

            //Assert
            _placesRepository.Verify(x => x.GetPlaces(), Times.Once);
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(mockArray);
        }

        [Fact]
        public async Task Get_NotValidInput_ReturnsNull()
        {
            //Arrange
            GetPlacesModel mockPlace = null;
            long id = 0;
            _placesRepository
               .Setup(x => x.GetPlace(id))
               .ReturnsAsync(() => mockPlace);

            //Act
            var result = await _service.GetPlace(id);

            //Assert
            _placesRepository.Verify(x => x.GetPlace(id), Times.Once);
            result.Should().BeNull();
        }
    }
}
