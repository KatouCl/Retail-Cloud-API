using System.ComponentModel.DataAnnotations;
using RetailCloud.Core.Entities;
using RetailCloud.Core.Entities.Enums;

namespace RetailCloud.Api.Dtos
{
    public class GroupProductDto : BaseEntityDto
    {
        [Required] public UserDto UserCreated { get; set; }
        [Required] public ProductType ProductType { get; set; }
        [Required] public string Name { get; set; }
        [Required] public bool IsMarked { get; set; }
    }
}