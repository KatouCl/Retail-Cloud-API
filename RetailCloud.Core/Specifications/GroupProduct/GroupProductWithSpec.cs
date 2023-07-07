using RetailCloud.Core.Specifications.Base;

namespace RetailCloud.Core.Specifications.GroupProduct
{
    public class GroupProductWithSpec : BaseSpecification<Entities.GroupProduct>
    {
        public GroupProductWithSpec(GroupProductSpecParams param)
            : base(x =>
                string.IsNullOrEmpty(param.Search) || x.Name.ToLower() == param.Search
            )
        {
            AddInclude(x => x.UserCreated);
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

        public GroupProductWithSpec(long id) : base(x => x.Id == id)
        {
        }
    }
}