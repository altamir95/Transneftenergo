using System.ComponentModel.DataAnnotations.Schema;

namespace Transneftenergo.DAL.Models
{
    ///счетчик электрической энергии
    public class ElectricEnergyMeter : Equipment {
        [ForeignKey("ElectricityMeasurementPointId")]
        public override ElectricityMeasurementPoint ElectricityMeasurementPoint { get; set; }
    }
}
