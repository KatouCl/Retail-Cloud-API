using RetailCloud.Core.Specifications.Base;
using RetailCloud.Core.Specifications.Organization;

namespace RetailCloud.Core.Specifications.Producer
{
    public class ProducerWithSpec : BaseSpecification<Entities.Producer>
    {
        public ProducerWithSpec(ProducerSpecParams param)
            : base(x =>
                (string.IsNullOrEmpty(param.Search) || x.ShortName.ToLower() == param.Search ||
                 string.IsNullOrEmpty(param.Search) || x.FullName.ToLower() == param.Search) &&
                (string.IsNullOrEmpty(param.Inn) || x.Inn == param.Inn) &&
                (string.IsNullOrEmpty(param.Kpp) || x.Kpp == param.Kpp) &&
                (string.IsNullOrEmpty(param.FsrarId) || x.FsrarId == param.FsrarId)
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

        public ProducerWithSpec(long id) : base(x => x.Id == id)
        {
        }
    }
}