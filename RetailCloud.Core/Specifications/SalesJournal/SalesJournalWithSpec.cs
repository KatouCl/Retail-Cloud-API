using RetailCloud.Core.Specifications.Base;

namespace RetailCloud.Core.Specifications.SalesJournal
{
    public class SalesJournalWithSpec : BaseSpecification<Entities.SalesJournal>
    {
        public SalesJournalWithSpec(SalesJournalSpecParams param)
            : base(x =>
                (string.IsNullOrEmpty(param.KktSerialNumber) || x.KktSerialNumber == param.KktSerialNumber)
            )
        {
            AddInclude(x => x.User);
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

        public SalesJournalWithSpec(long id) : base(x => x.Id == id)
        {
        }
    }
}