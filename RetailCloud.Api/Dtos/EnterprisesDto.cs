using System.ComponentModel.DataAnnotations;

namespace RetailCloud.Api.Dtos
{
    public class EnterprisesDto : BaseEntityDto
    {
        public OrganizationDto? OrganizationDto { get; set; }
        [Required] public long OrganizationId { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Kpp { get; set; }
        [Required] public string FsrarId { get; set; }
        [Required] public string ShortName { get; set; }
        [Required] public string FullName { get; set; }
        [Required] public string Address { get; set; }
        [Required] public string Telephone { get; set; }
        [Required] public string Email { get; set; }
        public string? Description { get; set; }
    }
}