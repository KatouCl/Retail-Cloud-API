using RetailCloud.Core.Entities.Enums;

namespace RetailCloud.Core.Entities
{
    public class Producer : BaseEntity
    {
        public OrganizationType OrganizationType { get; set; }
        public TaxIndexType TaxIndexType { get; set; }
        public string? Inn { get; set; }
        public string Kpp { get; set; }
        public string? FsrarId { get; set; }
        public string? ShortName { get; set; }
        public string FullName { get; set; }
        public int? Country { get; set; }
        public int? RegionCode { get; set; }
        public string? Description { get; set; }
        public string? Email { get; set; }
        public string? Telephone { get; set; }
    }
}