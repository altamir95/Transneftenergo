using System;
using System.Collections.Generic;

namespace Transneftenergo.DAL.Models
{
    /// точка измерения электроэнергии
    public class ElectricityMeasurementPoint
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public int? ElectricEnergyMeterId { get; set; }
        public ElectricEnergyMeter ElectricEnergyMeter { get; set; }

        public int? CurrentTransformerId { get; set; }
        public virtual CurrentTransformer CurrentTransformer { get; set; }

        public int? VoltageTransformerId { get; set; }
        public VoltageTransformer VoltageTransformer { get; set; }

        public int? ConsumptionObjectId { get; set; }
        public ConsumptionObject ConsumptionObject { get; set; }
        public List<CalculationAccountingDeviceElectricityMeasurementPoint> CalculationAccountingDeviceElectricityMeasurementPoints { get; set; }
        public ElectricityMeasurementPoint()
        {
            CalculationAccountingDeviceElectricityMeasurementPoints = new List<CalculationAccountingDeviceElectricityMeasurementPoint>();
        }
    }
}
