using System;
using System.Collections.Generic;

namespace Transneftenergo.DAL.Models
{
    //расчетный прибор учета
    public class CalculationAccountingDevice
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public List<CalculationAccountingDeviceElectricityMeasurementPoint> CalculationAccountingDeviceElectricityMeasurementPoints { get; set; }
        public CalculationAccountingDevice()
        {
            CalculationAccountingDeviceElectricityMeasurementPoints = new List<CalculationAccountingDeviceElectricityMeasurementPoint>();
        }
    }
}
