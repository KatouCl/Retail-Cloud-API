using RetailCloud.Core.Specifications.Base;

namespace RetailCloud.Core.Specifications.Organization
{
    public class OrganizationWithSpec : BaseSpecification<Entities.Organization>
    {
        public OrganizationWithSpec(OrganizationSpecParams param)
            : base(x =>
                (string.IsNullOrEmpty(param.Search) || x.Name.ToLower() == param.Search) &&
                (string.IsNullOrEmpty(param.Inn) || x.Inn == param.Inn)
            )
        {
            ApplyPaging(param.PageSize, param.PageSize * param.Page);
            if (!string.IsNullOrEmpty(param.Sort))
            {
                switch (param.Sort)
                {
                    case "asc":
                        AddOrderBy(x => x.Id);
                        break;
                    case "desc":
                        AddOrderByDecending(x => x.Id);
                        break;
                    default:
                        AddOrderBy(x => x.Id);
                        break;
                }
            }
        }

        public OrganizationWithSpec(long id) : base(x => x.Id == id)
        {
        }
    }
}