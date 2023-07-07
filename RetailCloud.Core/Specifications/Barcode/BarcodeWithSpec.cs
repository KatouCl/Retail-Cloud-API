using RetailCloud.Core.Specifications.Base;

namespace RetailCloud.Core.Specifications.Barcode
{
    public class BarcodeWithSpec : BaseSpecification<Entities.Barcode>
    {
        public BarcodeWithSpec(BarcodeSpecParams param)
            : base(x =>
                string.IsNullOrEmpty(param.Search) || x.Name.ToLower() == param.Search
            )
        {
            AddInclude(x => x.UserCreated);
            AddInclude(x => x.Product);
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

        public BarcodeWithSpec(long id) : base(x => x.Id == id)
        {
        }
    }
}