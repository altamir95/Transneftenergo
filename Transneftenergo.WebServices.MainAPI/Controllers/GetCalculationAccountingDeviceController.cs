using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Transneftenergo.BAL.Interfaces;

namespace Transneftenergo.WebServices.MainAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GetCalculationAccountingDeviceController : ControllerBase
    {
        private readonly ICalculationAccountingDeviceService _calculationAccountingDeviceService;


        public GetCalculationAccountingDeviceController(
            ICalculationAccountingDeviceService calculationAccountingDeviceService
            )
        {
            _calculationAccountingDeviceService = calculationAccountingDeviceService;
        }

        [HttpGet]
        public async Task<IActionResult> Get2018Year() =>
             new ObjectResult(await _calculationAccountingDeviceService.GetByYear(2018));
    }
}
