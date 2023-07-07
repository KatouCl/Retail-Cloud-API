using RetailCloud.Core.Specifications.Base;

namespace RetailCloud.Core.Specifications
{
    public partial class ProducerWithFilterOrganizationTypes : BaseSpecification<ProducerWithFilterOrganizationTypes.ProducerSpecParam>
    {
        public ProducerWithFilterOrganizationTypes(ProducerSpecParam param) : base(x =>
            (string.IsNullOrEmpty(param.Search) && (x.OrganizationType == param.OrganizationType)))
        {
        }
    }
}