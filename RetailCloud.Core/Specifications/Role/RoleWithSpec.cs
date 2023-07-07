using RetailCloud.Core.Specifications.Base;

namespace RetailCloud.Core.Specifications.Role
{
    public class RoleWithSpec : BaseSpecification<Entities.Role>
    {
        public RoleWithSpec(RoleSpecParams param)
            : base(x =>
                string.IsNullOrEmpty(param.Search) || x.Name.ToLower() == param.Search
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

        public RoleWithSpec(long id) : base(x => x.Id == id)
        {
        }
    }
}