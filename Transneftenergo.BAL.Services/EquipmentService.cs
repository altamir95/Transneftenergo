using System;
using System.Threading.Tasks;
using Transneftenergo.BAL.Interfaces;
using Transneftenergo.DAL.Interfaces;
using Transneftenergo.DAL.Models;

namespace Transneftenergo.BAL.Services
{
    public class EquipmentService<T> : IEquipmentService<T> where T : Equipment
    {
        private readonly IRepository<T> _equipment;

        public EquipmentService(IRepository<T> equipment)
        {
            _equipment = equipment;
        }

        public async Task<T> GetOverdueEquipment(int consumptionObjectId) =>
            await _equipment.GetFirstOrDefaultAsync(e => e.VerificationDate > DateTime.Now && e.ElectricityMeasurementPoint.ConsumptionObjectId == consumptionObjectId);
    }
}
