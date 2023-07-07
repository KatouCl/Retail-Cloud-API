using RetailCloud.Core.Specifications.Base;

namespace RetailCloud.Core.Specifications.Units
{
    public class UnitsWithSpec : BaseSpecification<Entities.Units>
    {
        public UnitsWithSpec(UnitsSpecParams param)
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

        public UnitsWithSpec(long id) : base(x => x.Id == id)
        {
        }
    }
}