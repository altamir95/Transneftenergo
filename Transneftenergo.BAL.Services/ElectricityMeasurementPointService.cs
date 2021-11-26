using System;
using System.Threading.Tasks;
using Transneftenergo.BAL.Interfaces;
using Transneftenergo.BAL.Models;
using Transneftenergo.DAL.Interfaces;
using Transneftenergo.DAL.Models;

namespace Transneftenergo.BAL.Services
{
    class ElectricityMeasurementPointService : IElectricityMeasurementPointService
    {
        private readonly IRepository<ElectricityMeasurementPoint> _electricityMeasurementPoint;

        private readonly IRepository<ElectricEnergyMeter> _electricEnergyMeter;
        private readonly IRepository<CurrentTransformer> _currentTransformer;
        private readonly IRepository<VoltageTransformer> _voltageTransformer;

        public ElectricityMeasurementPointService(
            IRepository<ElectricityMeasurementPoint> electricityMeasurementPoint,
            IRepository<ElectricEnergyMeter> electricEnergyMeter,
            IRepository<CurrentTransformer> currentTransformer,
            IRepository<VoltageTransformer> voltageTransformer
            )
        {
            _electricityMeasurementPoint = electricityMeasurementPoint;
            _electricEnergyMeter = electricEnergyMeter;
            _currentTransformer = currentTransformer;
            _voltageTransformer = voltageTransformer;
        }

        public async Task CreateForExistEquipment(ExistEquipmentIdsModel model)
        {

            if (
                !await _electricEnergyMeter.IsExist(eem => eem.Id == model.ElectricEnergyMeterId) &&
                !await _currentTransformer.IsExist(eem => eem.Id == model.CurrentTransformerId) &&
                !await _voltageTransformer.IsExist(eem => eem.Id == model.VoltageTransformerId)
                ) throw new Exception();

            var newElectricityMeasurementPoint = new ElectricityMeasurementPoint()
            {
                ElectricEnergyMeterId = model.ElectricEnergyMeterId,
                CurrentTransformerId = model.CurrentTransformerId,
                VoltageTransformerId = model.VoltageTransformerId
            };

            await _electricityMeasurementPoint.CreateAsync(newElectricityMeasurementPoint);

            await _electricityMeasurementPoint.SaveAsync();
        }
    }
}
