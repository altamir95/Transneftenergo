using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Transneftenergo.BAL.Interfaces;
using Transneftenergo.BAL.Models;

namespace Transneftenergo.WebServices.MainAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PostElectricityMeasurementPointController : ControllerBase
    {
        private readonly IElectricityMeasurementPointService _electricityMeasurementPointService;

        public PostElectricityMeasurementPointController(IElectricityMeasurementPointService electricityMeasurementPointService)
        {
            _electricityMeasurementPointService = electricityMeasurementPointService;
        }

        [HttpPost]
        public async Task<IActionResult> AddBySpecifyingEquipmentIds(ExistEquipmentIdsModel model)
        {
            if (model is null) return BadRequest();
            var result = await _electricityMeasurementPointService.CreateForExistEquipment(model);
            if (!result) return BadRequest();
            return Ok();
        }
    }
}
