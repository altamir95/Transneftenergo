using System;

namespace Transneftenergo.DAL.Models
{
    public class CalculationAccountingDeviceElectricityMeasurementPoint
    {
        public int Id { get; set; }
        public DateTime FromCAD { get; set; }
        public DateTime ToCAD { get; set; }
        public CalculationAccountingDevice CalculationAccountingDevice { get; set; }
        public DateTime FromEMP { get; set; }
        public DateTime ToEMP { get; set; }
        public ElectricityMeasurementPoint ElectricityMeasurementPoint { get; set; }
    }
}
