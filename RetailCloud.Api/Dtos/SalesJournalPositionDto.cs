using System.ComponentModel.DataAnnotations;
using RetailCloud.Api.Dtos;

namespace RetailCloud.Core.Entities
{
    public class SalesJournalPositionDto : BaseEntityDto
    {
        [Required] public ProductDto Product { get; set; }
        [Required] public SalesJournalDto SalesJournal { get; set; }

        /// <summary>
        /// Реализация товаров по свободной цене
        /// </summary>
        public string? ProductName { get; set; }

        /// <summary>
        /// CIS - марка. DataMatrix без криптохвоста служит для того чтобы нельзя продать уже проданный маркированный товар
        /// </summary>
        public string? Cis { get; set; }

        [Required] public long Price { get; set; }
        [Required] public double Quantity { get; set; }
    }
}