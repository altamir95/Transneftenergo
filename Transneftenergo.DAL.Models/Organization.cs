using System.Collections.Generic;

namespace Transneftenergo.DAL.Models
{
    public class Organization
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<SubsidiaryOrganization> SubsidiaryOrganizations { get; set; }

        public Organization()
        {
            SubsidiaryOrganizations = new List<SubsidiaryOrganization>();
        }

    }
}
