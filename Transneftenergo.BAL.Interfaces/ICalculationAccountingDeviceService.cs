using System.Collections.Generic;
using System.Threading.Tasks;
using Transneftenergo.DAL.Models;

namespace Transneftenergo.BAL.Interfaces
{
   public interface ICalculationAccountingDeviceService
    {
        Task<List<CalculationAccountingDevice>>  GetByYear(int year);
    }
}
