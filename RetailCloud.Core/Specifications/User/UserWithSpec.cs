using RetailCloud.Core.Specifications.Base;

namespace RetailCloud.Core.Specifications.User
{
    public class UserWithSpec : BaseSpecification<Entities.User>
    {
        public UserWithSpec(UserSpecParams param)
            : base(x =>
                string.IsNullOrEmpty(param.Search) || x.Name.ToLower() == param.Search
            )
        {
            AddInclude(x => x.Role);
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

        public UserWithSpec(long id) : base(x => x.Id == id)
        {
        }
    }
}