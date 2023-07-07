using RetailCloud.Api.Dtos;
using RetailCloud.Core.Entities;

namespace RetailCloud.Api.Mapper
{
    public static class ProductMapper
    {
        public static Product mapToProduct(this ProductDto productDto)
        {
            return new Product
            {
                Id = productDto.Id,
                DateChange = productDto.DateChange,
                DateCreate = productDto.DateCreate,
                IsDeleted = productDto.IsDeleted,
                UserCreated = productDto.UserCreated.mapToUser(),
                GroupProduct = productDto.GroupProduct.mapToGroupProduct(),
                Units = productDto.Units.mapToUnits(),
                Producer = productDto.Producer.mapToProducer(),
                TaxIndexType = productDto.TaxIndexType,
                ItemType = productDto.ItemType,
                Name = productDto.Name,
                PrintName = productDto.PrintName,
                Artikul = productDto.Artikul
            };
        }

        public static ProductDto mapToProductDto(this Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                DateChange = product.DateChange,
                DateCreate = product.DateCreate,
                IsDeleted = product.IsDeleted,
                UserCreated = product.UserCreated.mapToUserDto(),
                GroupProduct = product.GroupProduct.mapToGroupProductDto(),
                Units = product.Units.mapToUnitsDto(),
                Producer = product.Producer.mapToProducerDto(),
                TaxIndexType = product.TaxIndexType,
                ItemType = product.ItemType,
                Name = product.Name,
                PrintName = product.PrintName,
                Artikul = product.Artikul
            };
        }
    }
}