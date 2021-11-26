using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Transneftenergo.BAL.Interfaces;
using Transneftenergo.DAL.Models;

namespace Transneftenergo.WebServices.MainAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GetVoltageTransformerController : ControllerBase
    {
        private readonly IEquipmentService<VoltageTransformer> _equipmentService;

        public GetVoltageTransformerController(IEquipmentService<VoltageTransformer> equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [HttpGet("{consumptionObjectId}")]
        public async Task<IActionResult> GetOverdueEquipmentByConsumptionObject(int consumptionObjectId) =>
            new ObjectResult(await _equipmentService.GetOverdueEquipment(consumptionObjectId));
    }
}
