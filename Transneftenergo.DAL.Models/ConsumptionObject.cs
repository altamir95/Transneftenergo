using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transneftenergo.DAL.Models
{
    // Объект потребления
    public class ConsumptionObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public int SubsidiaryOrganizationId { get; set; }
        [ForeignKey("SubsidiaryOrganizationId")]
        public SubsidiaryOrganization SubsidiaryOrganization { get; set; }

        public List<ElectricityMeasurementPoint> ElectricityMeasurementPoints { get; set; }

        public List<ElectricitySupplyPoint> ElectricitySupplyPoints { get; set; }
        public ConsumptionObject()
        {
            ElectricityMeasurementPoints = new List<ElectricityMeasurementPoint>();

            ElectricitySupplyPoints = new List<ElectricitySupplyPoint>();
        }
    }
}
