using RetailCloud.Core.Specifications.Base;

namespace RetailCloud.Core.Specifications.SalesJournalPosition
{
    public class SalesJournalPositionWithSpec : BaseSpecification<Entities.SalesJournalPosition>
    {
        public SalesJournalPositionWithSpec(SalesJournalPositionSpecParams param)
            : base(x =>
                (string.IsNullOrEmpty(param.ProductName) || x.ProductName == param.ProductName)
            )
        {
            AddInclude(x => x.Product);
            AddInclude(x => x.SalesJournal);
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

        public SalesJournalPositionWithSpec(long id) : base(x => x.Id == id)
        {
        }
    }
}