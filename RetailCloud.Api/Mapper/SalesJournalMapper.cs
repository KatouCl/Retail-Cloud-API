using RetailCloud.Core.Entities;

namespace RetailCloud.Api.Mapper
{
    public static class SalesJournalMapper
    {
        public static SalesJournal mapToSalesJournal(this SalesJournalDto salesJournalDto)
        {
            return new SalesJournal
            {
                Id = salesJournalDto.Id,
                DateChange = salesJournalDto.DateChange,
                DateCreate = salesJournalDto.DateCreate,
                IsDeleted = salesJournalDto.IsDeleted,
                User = salesJournalDto.UserDto.mapToUser(),
                PaymentStatusType = salesJournalDto.PaymentStatusType,
                PaymentMethodType = salesJournalDto.PaymentMethodType,
                TotalPrice = salesJournalDto.TotalPrice,
                KktSerialNumber = salesJournalDto.KktSerialNumber,
                PaymentToken = salesJournalDto.PaymentToken,
                PaymentId = salesJournalDto.PaymentId,
                NumberTransaction = salesJournalDto.NumberTransaction,
                CheckNumber = salesJournalDto.CheckNumber,
                Rrn = salesJournalDto.Rrn,
                FiscalNumberDocument = salesJournalDto.FiscalNumberDocument,
                SessionNumber = salesJournalDto.SessionNumber,
                QR_URL = salesJournalDto.QR_URL,
                QR_Sign = salesJournalDto.QR_Sign
            };
        }

        public static SalesJournalDto mapToSalesJournalDto(this SalesJournal salesJournal)
        {
            return new SalesJournalDto
            {
                Id = salesJournal.Id,
                DateChange = salesJournal.DateChange,
                DateCreate = salesJournal.DateCreate,
                IsDeleted = salesJournal.IsDeleted,
                UserDto = salesJournal.User.mapToUserDto(),
                PaymentStatusType = salesJournal.PaymentStatusType,
                PaymentMethodType = salesJournal.PaymentMethodType,
                TotalPrice = salesJournal.TotalPrice,
                KktSerialNumber = salesJournal.KktSerialNumber,
                PaymentToken = salesJournal.PaymentToken,
                PaymentId = salesJournal.PaymentId,
                NumberTransaction = salesJournal.NumberTransaction,
                CheckNumber = salesJournal.CheckNumber,
                Rrn = salesJournal.Rrn,
                FiscalNumberDocument = salesJournal.FiscalNumberDocument,
                SessionNumber = salesJournal.SessionNumber,
                QR_URL = salesJournal.QR_URL,
                QR_Sign = salesJournal.QR_Sign
            };
        }
    }
}