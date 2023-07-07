using System.ComponentModel.DataAnnotations;
using RetailCloud.Core.Entities.Enums;

namespace RetailCloud.Api.Dtos
{
    public class ProducerDto : BaseEntityDto
    {
        [Required] public OrganizationType OrganizationType { get; set; }
        [Required] public TaxIndexType TaxIndexType { get; set; }
        public string? Inn { get; set; }
        [Required] public string Kpp { get; set; }
        public string? FsrarId { get; set; }
        public string? ShortName { get; set; }
        [Required] public string FullName { get; set; }
        public int? Country { get; set; }
        public int? RegionCode { get; set; }
        public string? Description { get; set; }
        public string? Email { get; set; }
        public string? Telephone { get; set; }
    }
}