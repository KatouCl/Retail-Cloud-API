using RetailCloud.Core.Entities.Enums;

namespace RetailCloud.Core.Entities
{
    public class SalesJournal : BaseEntity
    {
        public User User { get; set; }
        public PaymentStatusType PaymentStatusType { get; set; }
        public PaymentMethodType PaymentMethodType { get; set; }
        public long TotalPrice { get; set; }
        public string KktSerialNumber { get; set; }
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