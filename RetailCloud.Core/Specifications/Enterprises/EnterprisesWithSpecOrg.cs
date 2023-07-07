using RetailCloud.Core.Specifications.Base;

namespace RetailCloud.Core.Specifications.Enterprises
{
    public class EnterprisesWithSpecOrg : BaseSpecification<Entities.Enterprises>
    {
        public EnterprisesWithSpecOrg(EnterprisesSpecParams param)
            : base(x =>
                (string.IsNullOrEmpty(param.Search) || x.Name.ToLower() == param.Search ||
                 string.IsNullOrEmpty(param.Search) || x.ShortName.ToLower() == param.Search ||
                 string.IsNullOrEmpty(param.Search) || x.FullName.ToLower() == param.Search) &&
                (string.IsNullOrEmpty(param.Kpp) || x.Kpp == param.Kpp) &&
                (string.IsNullOrEmpty(param.FsrarId) || x.FsrarId == param.FsrarId) &&
                (string.IsNullOrEmpty(param.Email) || x.Email.ToLower() == param.Email) &&
                (string.IsNullOrEmpty(param.Telephone) || x.Telephone.ToLower() == param.Telephone)
            )
        {
            AddInclude(x => x.Organization);
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

        public EnterprisesWithSpecOrg(long id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Organization);
        }
    }
}