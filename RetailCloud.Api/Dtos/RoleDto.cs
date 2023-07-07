using System.ComponentModel.DataAnnotations;

namespace RetailCloud.Api.Dtos
{
    public class RoleDto : BaseEntityDto
    {
        [Required] public string Name { get; set; }
    }
}