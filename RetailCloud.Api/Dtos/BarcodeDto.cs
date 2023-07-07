using System.ComponentModel.DataAnnotations;
using RetailCloud.Core.Entities;

namespace RetailCloud.Api.Dtos
{
    public class BarcodeDto : BaseEntityDto
    {
        [Required] public ProductDto Product { get; set; }
        [Required] public UserDto UserCreated { get; set; }
        [Required] public string Name { get; set; }
        [Required] public long Price { get; set; }
    }
}