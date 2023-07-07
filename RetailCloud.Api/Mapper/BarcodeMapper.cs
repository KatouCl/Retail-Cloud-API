using RetailCloud.Api.Dtos;
using RetailCloud.Core.Entities;

namespace RetailCloud.Api.Mapper
{
    public static class BarcodeMapper
    {
        public static Barcode mapToBarcode(this BarcodeDto barcodeDto)
        {
            return new Barcode
            {
                Id = barcodeDto.Id,
                DateChange = barcodeDto.DateChange,
                DateCreate = barcodeDto.DateCreate,
                IsDeleted = barcodeDto.IsDeleted,
                Product = barcodeDto.Product.mapToProduct(),
                UserCreated = barcodeDto.UserCreated.mapToUser(),
                Name = barcodeDto.Name,
                Price = barcodeDto.Price,
            };
        }

        public static BarcodeDto mapToBarcodeDto(this Barcode barcode)
        {
            return new BarcodeDto
            {
                Id = barcode.Id,
                DateChange = barcode.DateChange,
                DateCreate = barcode.DateCreate,
                IsDeleted = barcode.IsDeleted,
                Product = barcode.Product.mapToProductDto(),
                UserCreated = barcode.UserCreated.mapToUserDto(),
                Name = barcode.Name,
                Price = barcode.Price,
            };
        }
    }
}