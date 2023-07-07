using RetailCloud.Core.Specifications.Base;

namespace RetailCloud.Core.Specifications.Product
{
    public class ProductWithSpec : BaseSpecification<Entities.Product>
    {
        public ProductWithSpec(ProductSpecParams param)
            : base(x =>
                string.IsNullOrEmpty(param.Search) || x.Name.ToLower() == param.Search
            )
        {
            AddInclude(x => x.UserCreated);
            AddInclude(x => x.GroupProduct);
            AddInclude(x => x.Producer);
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

        public ProductWithSpec(long id) : base(x => x.Id == id)
        {
        }

        public ProductWithSpec(GroupProduct.GroupProductSpecParams id)
        {
            throw new System.NotImplementedException();
        }
    }
}