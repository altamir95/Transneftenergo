using System.Threading.Tasks;
using Transneftenergo.BAL.Interfaces;
using Transneftenergo.DAL.Interfaces;
using Transneftenergo.DAL.Models;

namespace Transneftenergo.BAL.Services
{
    public class CalculationAccountingDeviceService: ICalculationAccountingDeviceService
    {
        private readonly IRepository<CalculationAccountingDevice> _calculationAccountingDevice;


        public CalculationAccountingDeviceService(
            IRepository<CalculationAccountingDevice> calculationAccountingDevice
            )
        {
            _calculationAccountingDevice = calculationAccountingDevice;
        }

        async public Task<CalculationAccountingDevice> GetByYear(int year) =>
            await _calculationAccountingDevice.GetFirstOrDefaultAsync(d => d.From.Year >= year && d.To.Year <= year);
    }
}
