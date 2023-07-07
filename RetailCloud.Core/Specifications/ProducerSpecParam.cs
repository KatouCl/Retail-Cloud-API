using RetailCloud.Core.Entities.Enums;
using RetailCloud.Core.Specifications.Base;

namespace RetailCloud.Core.Specifications
{
    public partial class ProducerWithFilterOrganizationTypes
    {
        public class ProducerSpecParam : BaseSpecPrams
        {
            public OrganizationType OrganizationType { get; set; }
        }
    }
}