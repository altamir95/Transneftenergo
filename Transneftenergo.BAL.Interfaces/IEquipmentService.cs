using System.Threading.Tasks;
using Transneftenergo.DAL.Models;

namespace Transneftenergo.BAL.Interfaces
{
    public interface IEquipmentService<T> where T : Equipment
    {
        Task<T> GetOverdueEquipment(int consumptionObjectId);
    }
}
