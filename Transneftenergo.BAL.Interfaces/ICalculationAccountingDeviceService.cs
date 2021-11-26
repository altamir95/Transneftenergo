using System.Threading.Tasks;
using Transneftenergo.DAL.Models;

namespace Transneftenergo.BAL.Interfaces
{
   public interface ICalculationAccountingDeviceService
    {
        Task<CalculationAccountingDevice> GetByYear(int year);
    }
}
