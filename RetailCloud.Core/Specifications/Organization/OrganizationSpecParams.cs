using RetailCloud.Core.Entities;
using RetailCloud.Core.Specifications.Base;

namespace RetailCloud.Core.Specifications.Organization
{
    public class OrganizationSpecParams : BaseSpecPrams
    {
        public string? Inn { get; set; }
        // public OrgType? Type { get; set; }
    }
}