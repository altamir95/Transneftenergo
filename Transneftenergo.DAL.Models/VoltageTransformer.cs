using System.ComponentModel.DataAnnotations.Schema;

namespace Transneftenergo.DAL.Models
{
    //трансформатор напряжения 
    public class VoltageTransformer : Equipment
    {
        public decimal KTN { get; set; }
        [ForeignKey("ElectricityMeasurementPointId")]
        public override ElectricityMeasurementPoint ElectricityMeasurementPoint { get; set; }

    }
}
