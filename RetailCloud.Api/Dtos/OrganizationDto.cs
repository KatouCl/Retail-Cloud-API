using System.ComponentModel.DataAnnotations;
using RetailCloud.Core.Entities;

namespace RetailCloud.Api.Dtos
{
    public class OrganizationDto : BaseEntityDto
    {
        [Required] public Type Type { get; set; }
        [Required] public string Inn { get; set; }
        [Required] public string Name { get; set; }
        public string? Description { get; set; }
        [Required] public string Email { get; set; }
        [Required] public string Telephone { get; set; }
    }
}