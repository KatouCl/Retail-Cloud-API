using System.ComponentModel.DataAnnotations;
using RetailCloud.Api.Dtos;

namespace RetailCloud.Core.Entities
{
    public class UnitsDto : BaseEntityDto
    {
        [Required] public UserDto UserCreated { get; set; }
        [Required] public string Name { get; set; }
    }
}