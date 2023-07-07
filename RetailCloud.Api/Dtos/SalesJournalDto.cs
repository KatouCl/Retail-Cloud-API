using System.ComponentModel.DataAnnotations;
using RetailCloud.Api.Dtos;
using RetailCloud.Core.Entities.Enums;

namespace RetailCloud.Core.Entities
{
    public class SalesJournalDto : BaseEntityDto
    {
        [Required] public UserDto UserDto { get; set; }
        [Required] public PaymentStatusType PaymentStatusType { get; set; }
        [Required] public PaymentMethodType PaymentMethodType { get; set; }
        [Required] public long TotalPrice { get; set; }
        [Required] public string KktSerialNumber { get; set; }
        public string? PaymentToken { get; set; }
        public string? PaymentId { get; set; }
        public string? NumberTransaction { get; set; }
        public string? CheckNumber { get; set; }
        public string? Rrn { get; set; }
        public string? FiscalNumberDocument { get; set; }
        public int? SessionNumber { get; set; }
        public string? QR_URL { get; set; }
        public string? QR_Sign { get; set; }
    }
}