using RetailCloud.Core.Specifications.Base;

namespace RetailCloud.Core.Specifications.Enterprises
{
    public class EnterprisesSpecParams : BaseSpecPrams
    {
        public string? Kpp { get; set; }
        public string? FsrarId { get; set; }
        public string? Email { get; set; }
        public string? Telephone { get; set; }
    }
}