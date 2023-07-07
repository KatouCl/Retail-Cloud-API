using RetailCloud.Core.Entities;

namespace RetailCloud.Api.Mapper
{
    public static class SalesJournalPositionMapper
    {
        public static SalesJournalPosition mapToSalesJournalPosition(
            this SalesJournalPositionDto salesJournalPositionDto)
        {
            return new SalesJournalPosition
            {
                Id = salesJournalPositionDto.Id,
                DateChange = salesJournalPositionDto.DateChange,
                DateCreate = salesJournalPositionDto.DateCreate,
                IsDeleted = salesJournalPositionDto.IsDeleted,
                Product = salesJournalPositionDto.Product.mapToProduct(),
                SalesJournal = salesJournalPositionDto.SalesJournal.mapToSalesJournal(),
                ProductName = salesJournalPositionDto.ProductName,
                Cis = salesJournalPositionDto.Cis,
                Price = salesJournalPositionDto.Price,
                Quantity = salesJournalPositionDto.Quantity,
            };
        }

        public static SalesJournalPositionDto mapToSalesJournalPositionDto(
            this SalesJournalPosition salesJournalPosition)
        {
            return new SalesJournalPositionDto
            {
                Id = salesJournalPosition.Id,
                DateChange = salesJournalPosition.DateChange,
                DateCreate = salesJournalPosition.DateCreate,
                IsDeleted = salesJournalPosition.IsDeleted,
                Product = salesJournalPosition.Product.mapToProductDto(),
                SalesJournal = salesJournalPosition.SalesJournal.mapToSalesJournalDto(),
                ProductName = salesJournalPosition.ProductName,
                Cis = salesJournalPosition.Cis,
                Price = salesJournalPosition.Price,
                Quantity = salesJournalPosition.Quantity,
            };
        }
    }
}