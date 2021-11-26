using System.ComponentModel.DataAnnotations.Schema;

namespace Transneftenergo.DAL.Models
{
    ///трансформатор тока
    public class CurrentTransformer : Equipment
    {
        public decimal KTT { get; set; }
        [ForeignKey("ElectricityMeasurementPointId")]
        public override ElectricityMeasurementPoint ElectricityMeasurementPoint { get; set; }
    }
}
