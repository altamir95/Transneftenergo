using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transneftenergo.BAL.Interfaces;
using Xunit;

namespace Transneftenergo.WebServices.MainAPI.Tests
{
    public class PostElectricityMeasurementPointControllerTests
    {
        [Fact]
        public async Task IfReservationRoomDateTimeIsNotSpecifiedAsync()
        {
            // Arrange
            var mock = new Mock<IElectricityMeasurementPointService>();
            mock.Setup(repo => repo.CreateForExistEquipment(null)).Returns(RetutnFalse());
            Controllers.PostElectricityMeasurementPointController controller = new Controllers.PostElectricityMeasurementPointController(mock.Object);

            // act
            var result = await controller.AddBySpecifyingEquipmentIds(null);
            var badResult = result as BadRequestResult;

            // assert
            Assert.NotNull(badResult);
        }

        static async Task<bool> RetutnFalse()
        {
            return false;
        }
    }
}
