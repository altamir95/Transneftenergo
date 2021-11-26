using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Transneftenergo.BAL.Interfaces;
using Transneftenergo.DAL.Models;

namespace Transneftenergo.WebServices.MainAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GetElectricEnergyMeterController : ControllerBase
    {
        private readonly IEquipmentService<ElectricEnergyMeter> _equipmentService;
        public GetElectricEnergyMeterController(IEquipmentService<ElectricEnergyMeter> equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [HttpGet("{consumptionObjectId}")]
        public async Task<IActionResult> GetOverdueEquipmentByConsumptionObject(int consumptionObjectId) =>
            new ObjectResult(await _equipmentService.GetOverdueEquipment(consumptionObjectId));
    }
}
