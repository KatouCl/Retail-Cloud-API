using System.ComponentModel.DataAnnotations;
using RetailCloud.Core.Entities;
using RetailCloud.Core.Entities.Enums;

namespace RetailCloud.Api.Dtos
{
    public class ProductDto : BaseEntityDto
    {
        [Required] public GroupProductDto GroupProduct { get; set; }
        [Required] public UserDto UserCreated { get; set; }
        [Required] public UnitsDto Units { get; set; }
        [Required] public ProducerDto Producer { get; set; }
        [Required] public TaxIndexType TaxIndexType { get; set; }
        [Required] public ItemType ItemType { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string PrintName { get; set; }
        public string? Artikul { get; set; }
    }
}