using System.Threading.Tasks;
using Transneftenergo.BAL.Models;

namespace Transneftenergo.BAL.Interfaces
{
    public interface IElectricityMeasurementPointService
    {
        Task CreateForExistEquipment(ExistEquipmentIdsModel model);
    }
}
