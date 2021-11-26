using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transneftenergo.DAL.Models
{
    public class SubsidiaryOrganization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public int OrganizationId { get; set; }
        [ForeignKey("OrganizationId")]
        public Organization Organization { get; set; }

        public List<ConsumptionObject> ConsumptionObjects { get; set; }

        public SubsidiaryOrganization()
        {
            ConsumptionObjects = new List<ConsumptionObject>();
        }
    }
}
