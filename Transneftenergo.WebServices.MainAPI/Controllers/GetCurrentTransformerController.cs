using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Transneftenergo.BAL.Interfaces;
using Transneftenergo.DAL.Models;

namespace Transneftenergo.WebServices.MainAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GetCurrentTransformerController : ControllerBase
    {
        private readonly IEquipmentService<CurrentTransformer> _equipmentService;

        public GetCurrentTransformerController(
         IEquipmentService<CurrentTransformer> equipmentService
            )
        {
            _equipmentService = equipmentService;
        }

        [HttpGet("{consumptionObjectId}")]
        public async Task<IActionResult> GetOverdueEquipmentByConsumptionObject(int consumptionObjectId) =>
            new ObjectResult(await _equipmentService.GetOverdueEquipment(consumptionObjectId));
    }
}
